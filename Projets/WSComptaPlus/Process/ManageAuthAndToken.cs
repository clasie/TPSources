using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using TokenHandler;
using TokenHandler.Constants;
using TokenHandler.Models;
using WSComptaPlus.Models;

namespace WSComptaPlus.Process
{
    public class ManageAuthAndToken
    {
        private static readonly Lazy<ManageAuthAndToken> lazy =
            new Lazy<ManageAuthAndToken>(() => new ManageAuthAndToken());

        public static ManageAuthAndToken Instance { get { return lazy.Value; } }

        private ManageAuthAndToken()
        {
        }
        /// <summary>
        /// Get a token if the user exists.
        /// </summary>
        /// <returns></returns>
        public LoginResponse Login(TokenHandler.Models.LoginRequest data) {

            return ((BasicAuth.Auth.Instance.UserExists(new User() { Name = data.Username, PassWord = data.Password })).Exists)?         
                new TokenHandler.Models.LoginResponse { Token = Token.Instance.createToken(data.Username), Message = TokenKey.MessageTokenForUser, Code = TokenKey.CodeUserExists } ://user found -> get new Token
                new TokenHandler.Models.LoginResponse { Token = string.Empty, Message = TokenKey.MessageNoTokenForUnknownUser, Code = TokenKey.CodeUnknownUser };//no user found -> no token            
        }
        /// <summary>
        /// 
        /// </summary>
        public void ValidateToken() {

            string resultValidation = Token.Instance.GetKeyInHeader();
            string regexKey = TokenKey.TokenPrefix;
            Regex regex = new Regex(regexKey);
            Match match = regex.Match(resultValidation);
            string tokenFound = "";
            if (match.Success)
            {
                tokenFound = Token.Instance.GetTokenFromAuthHeaderString(resultValidation);
                if (!Token.Instance.CheckTokenValidity(tokenFound).IsValidKey) {
                    throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenInvalid);
                }
            } else {
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);
            }
        }
    }
}