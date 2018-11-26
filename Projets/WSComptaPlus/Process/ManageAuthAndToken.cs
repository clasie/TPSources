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
    /// <summary>
    /// Orchestrates the businee process of Login/Token authentification/creation
    /// </summary>
    public class ManageAuthAndToken
    {
        /// <summary>
        /// Simplifies the call
        /// </summary>
        public static ManageAuthAndToken Instance { get { return new ManageAuthAndToken(); } }

        /// <summary>
        /// Verify if the user exists
        /// </summary>
        /// <returns></returns>
        public LoginResponse Login(TokenHandler.Models.LoginRequest data) {
            var token = new Token();
            return ((BasicAuth.Auth.Instance.UserExists(new User() { Name = data.Username, PassWord = data.Password })).Exists)?      
                //We found the user, we create a token  and send it to him   
                new TokenHandler.Models.LoginResponse { Token = token.createToken(data.Username), Message = TokenKey.MessageTokenForUser, Code = TokenKey.CodeUserExists } :
                //user not found, we provide a message explaning
                new TokenHandler.Models.LoginResponse { Token = string.Empty, Message = TokenKey.MessageNoTokenForUnknownUser, Code = TokenKey.CodeUnknownUser };         
        }
        /// <summary>
        /// 
        /// </summary>
        public void ValidateToken() {
            //Get the Autorization header content if any.
            var token = new Token();
            string resultValidation = token.GetKeyInHeader();
            Regex regex = new Regex(TokenKey.TokenPrefix);
            Match match = regex.Match(resultValidation);
            string tokenFound = "";
            //This header is satifying the prefix constraint (== TokenKey.TokenPrefix) 
            if (match.Success)
            {
                //Extract the Token
                tokenFound = token.GetTokenFromAuthHeaderString(resultValidation);
                //The tokebn is valid
                if (!token.CheckTokenValidity(tokenFound).IsValidKey) {
                    //Token refused
                    throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenInvalid);
                }
            } else {
                //The prefix token is not accepted.
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);
            }
        }
    }
}