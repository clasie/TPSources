using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
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
        /// This method orchestrate Auth and Token features
        /// </summary>
        /// <returns></returns>
        public LoginResponse Login(TokenHandler.Models.LoginRequest data) {

            return ((BasicAuth.Auth.Instance.UserExists(new User() { Name = data.Username, PassWord = data.Password })).Exists)?         
                new TokenHandler.Models.LoginResponse { Token = Token.Instance.createToken(data.Username), Message = TokenKey.MessageTokenForUser, Code = TokenKey.CodeUserExists } ://user found -> get new Token
                new TokenHandler.Models.LoginResponse { Token = string.Empty, Message = TokenKey.MessageNoTokenForUnknownUser, Code = TokenKey.CodeUnknownUser };//no user found -> no token            
        }
        public LoginResponse ValidateToken() {
            //ok arrive ici
            //Tester la clé
            string resultValidation = Token.Instance.IsValidKey(TokenKey.GeneratedKeyToTest);
            //IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            //WebHeaderCollection headers = request.Headers;
            //StringBuilder sb = new StringBuilder();
            //foreach (string headerName in headers.AllKeys)
            //{
            //    sb.Append(" headerName: " + headers[headerName]);
            //}
            var log = new LoginResponse();
            log.Message = resultValidation; // sb.ToString();
            //1 get from header
            return log; // new LoginResponse();
        }
    }
}