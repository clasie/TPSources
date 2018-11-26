using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TokenHandler.Constants;

namespace TokenHandler
{
    /// <summary>
    /// 
    /// ----------------------------------------------
    ///             JWT Token protection
    /// ----------------------------------------------
    /// 
    /// 
    /// 1- How is it implemented in this WCF Web service?
    /// 
    /// We have an 'Inspector' class method (WSComptaPlus.CustomBehaivious.TokenInspector.BeforeCall())
    /// targeted to take the hand on each try to consume any WCF interface before entering it if the
    /// interface method called is decorated wwhith [TokenInspector].
    /// 
    /// While hanving the hand the inspector method 'BeforeCall()' call 'ManageAuthAndToken.Instance.ValidateToken();'.
    /// 
    /// This 'ValidateToken()' will throw 'TokenHandler.CustomException.InvalidTokenException' if
    /// the Token passed in Header is not recognized as signed by this web service.
    /// 
    /// 
    /// 2- What is JWT ? https://jwt.io/introduction/
    /// 
    /// 
    /// 3- How to install/uninstall jwt ?
    /// 
    /// uninstall-package newtonsoft.json -force
    /// install-package newtonsoft.json
    /// 
    /// </summary>
    public class Token
    {
        public string GetKeyInHeader()
        {
            return WebOperationContext.Current.IncomingRequest.Headers
                .GetValues("Authorization")[TokenKey.ExpectedPlaceToFindHeader].ToString();
        }
        public string GetTokenFromAuthHeaderString(string authHeader)
        {
            return authHeader.StartsWith(TokenHandler.Constants.TokenKey.PrefixSetByTheCallerBeforeTheKey) ?
                authHeader.Substring(7) : authHeader;

        }
        private bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues(TokenKey.HeaderTokenToUse, out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith(TokenHandler.Constants.TokenKey.PrefixSetByTheCallerBeforeTheKey) ? 
                bearerToken.Substring(TokenKey.TokenPrefixRaw.Length) : bearerToken;
            return true;
        }
        public TokenHandler.Models.TokenCheckResult CheckTokenValidity(string token)
        {
            TokenHandler.Models.TokenCheckResult tokenCheckResult = new TokenHandler.Models.TokenCheckResult();
            try
            {
                const string sec = TokenHandler.Constants.TokenKey.PrivateKey;
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
                Microsoft.IdentityModel.Tokens.SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = TokenKey.Audience,
                    ValidIssuer = TokenKey.Issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                handler.ValidateToken(TokenHandler.Constants.TokenKey.GeneratedKeyToTest, 
                    validationParameters, out securityToken);
                tokenCheckResult.IsValidKey = true;
            }
            catch (Microsoft.IdentityModel.Tokens.SecurityTokenValidationException e)
            {
                tokenCheckResult.IsValidKey = false;
                tokenCheckResult.HttpStatusCode = HttpStatusCode.Unauthorized;
                tokenCheckResult.ErrorMessage = string.Format("{0}", e.ToString());
                //log here
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);
            }
            catch (Exception ex)
            {
                tokenCheckResult.IsValidKey = false;
                tokenCheckResult.HttpStatusCode = HttpStatusCode.Unauthorized;
                tokenCheckResult.ErrorMessage = string.Format("{0}", ex.ToString());
                //log here
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);

            }
            return tokenCheckResult;
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, Microsoft.IdentityModel.Tokens.SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

        public string createToken(string username)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(TokenKey.TokenDaysLive);

            //To encrypt the private token -> http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create an identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            });
            const string sec = TokenHandler.Constants.TokenKey.PrivateKey;
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials 
                = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(
                        issuer: TokenKey.Issuer, 
                        audience: TokenKey.Audience,
                        subject: claimsIdentity, 
                        notBefore: issuedAt, 
                        expires: expires, 
                        signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
