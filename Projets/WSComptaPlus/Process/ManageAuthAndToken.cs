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
using TokenHandler.Utils;
using WSComptaPlus.Models;

namespace WSComptaPlus.Process
{
    /// <summary>
    /// Orchestrates the businee process of Login/Token authentification/creation
    /// </summary>
    public class ManageAuthAndToken
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(TokenKey.NormalLogsNameSpace);
        /// <summary>
        /// Simplifies the call
        /// </summary>
        public static ManageAuthAndToken Instance { get { return new ManageAuthAndToken(); } }

        /// <summary>
        /// Verify if the user exists
        /// </summary>
        /// <returns></returns>
        public LoginResponse Login(TokenHandler.Models.LoginRequest data) {
            try
            {
                var token = new Token();
                //return ((BasicAuth.Auth.Instance.UserExists(new User() { Name = data.Username, PassWord = data.Password })).Exists)?
                if ((BasicAuth.Auth.Instance.UserExists(new User() { Name = data.Username, PassWord = data.Password })).Exists)
                {
                    //We found the user, we create a token  and send it back to him   
                    var resp = new TokenHandler.Models.LoginResponse
                    {
                        Token = token.createToken(
                            data.Username,
                            ApplicationData.Instance.TokenDaysLive,
                            ApplicationData.Instance.PrivateTokenKey),
                        Message = TokenKey.MessageTokenForUser,
                        Code = ApplicationData.Instance.CodeRetourLoginOk
                    };
                    return resp;
                }
                else
                {
                    //user not found, we provide an explanation message 
                    var resp = new TokenHandler.Models.LoginResponse { Token = string.Empty, Message = TokenKey.MessageNoTokenForUnknownUser, Code = ApplicationData.Instance.CodeRetourLoginKo };
                    return resp;
                }
            }
            catch (Exception ex) {

                log.Error(FormatMessages.getLogMessage(
                this.GetType().Name,
                System.Reflection.MethodBase.GetCurrentMethod().Name,
                string.Concat("LoginRequest data : ", data.ToString()),
                ex.ToString()));

                var resp = new TokenHandler.Models.LoginResponse { Token = string.Empty, Message = TokenKey.MessageNoTokenForUnknownUser, Code = ApplicationData.Instance.CodeRetourLoginKo };
                return resp;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ValidateToken() {
            try { 
            //Get the Autorization header content if any.
            var token = new Token();
            string headerFound = token.GetTokenInHeader();
            Regex regex = new Regex(TokenKey.TokenPrefix);
            Match match = regex.Match(headerFound);
            //This header is satifying the prefix constraint (== TokenKey.TokenPrefix) 
            if (match.Success)
            {
                //Extract the Token
                var tokenFound = token.GetTokenFromAuthHeaderString(headerFound);
                //The tokebn is valid
                if (!token.CheckTokenValidity(tokenFound, ApplicationData.Instance.PrivateTokenKey).IsValidKey) {
                    //Token refused
                    throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenInvalid);
                }
            } else {
                //The prefix token is not accepted.
                throw new TokenHandler.CustomException.InvalidTokenException(TokenKey.TokenNotFound);
            }
            }
            catch (Exception ex)
            {
                log.Error(FormatMessages.getLogMessage(
                this.GetType().Name,
                System.Reflection.MethodBase.GetCurrentMethod().Name,
                string.Concat(TokenKey.NoMethodParams),
                ex.ToString()));

                throw ex;
            }
        }
    }
}