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

namespace TokenHandler
{
    public class Token : DelegatingHandler
    {
        private static readonly Lazy<Token> lazy =
            new Lazy<Token>(() => new Token());

        public static Token Instance { get { return lazy.Value; } }

        private Token()
        {
        }

        //public bool HasKey()
        //{
        //    return true; ;
        //}
        //public string GetKey() {
        //    ERPDynamics.Response resp = new ERPDynamics.Response();
        //    resp.Message = "Ko!";
        //    throw new WebFaultException<ERPDynamics.Response>(resp, HttpStatusCode.Forbidden);
        //    return "eeeeeeeiiioooo";
        //}
        public string GetKeyInHeader()
        {


            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            return headers.Get("Authorization");
        }

        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            //Bearer stuff
            token = bearerToken.StartsWith(TokenHandler.Constants.TokenKey.PrefixSetByTheCallerBeforeTheKey) ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        public Task<HttpResponseMessage> SendAsyncAccess(HttpRequestMessage request, CancellationToken cancellationToken) {
            return SendAsync(request, cancellationToken);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                const string sec = TokenHandler.Constants.TokenKey.PrivateKey;
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));

                Microsoft.IdentityModel.Tokens.SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "http://localhost:50191",
                    ValidIssuer = "http://localhost:50191",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (Microsoft.IdentityModel.Tokens.SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            //If not authorized the user must go against the Login service.
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });            
        }
        public string IsValidKey(string token)
        {
            token = createToken("test");

            HttpStatusCode statusCode;
            //string token;
            //determine whether a jwt exists or not
            //if (!TryRetrieveToken(request, out token))
            //{
            //    statusCode = HttpStatusCode.Unauthorized;
            //    //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
            //    //return base.SendAsync(request, cancellationToken);
            //}

            try
            {
                const string sec = TokenHandler.Constants.TokenKey.PrivateKey;
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));

                Microsoft.IdentityModel.Tokens.SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "http://localhost:50191",
                    ValidIssuer = "http://localhost:50191",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                handler.ValidateToken(TokenHandler.Constants.TokenKey.GeneratedKeyToTest, validationParameters, out securityToken);
                var ccc = securityToken.ToString();
                //Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                //HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                return "Ok key valide";
                //return base.SendAsync(request, cancellationToken);
            }
            catch (Microsoft.IdentityModel.Tokens.SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
                return "unauthorized 1";
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
                return ex.Message + " " + ex.InnerException; //,"unauthorized 2";
            }
            return "unauthorized 3";
            //If not authorized the user must go against the Login service.
            //return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, Microsoft.IdentityModel.Tokens.SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            return true;
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
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //To encrypt the private token -> http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
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
                        issuer: "http://localhost:50191", 
                        audience: "http://localhost:50191",
                        subject: claimsIdentity, 
                        notBefore: issuedAt, 
                        expires: expires, 
                        signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
