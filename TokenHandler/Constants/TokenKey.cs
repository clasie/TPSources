using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Constants
{
    public static class TokenKey
    {
        //Private token key
        public const string PrivateKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        //Prefix expected in header
        public const string PrefixSetByTheCallerBeforeTheKey = "Bearer ";
        //Login user found
        public const string CodeUserExists = "10000";        
        public const string MessageTokenForUser = "New token created";
        //Login user not found        
        public const string CodeUnknownUser = "10001";
        public const string MessageNoTokenForUnknownUser = "No token, the user is unknown";
        public const string GeneratedKeyToTest =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRvdG8iLCJuYmYiOjE1NDI4ODk2NzEsImV4cCI6MTU0MzQ5NDQ3MSwiaWF0IjoxNTQyODg5NjcxLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDE5MSJ9.5rOp3blnH2JepUcZxZdZ23T5DZrd4AgQnaWugJG_fGc";
        public const string GeneratedKeyToTestBidon =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRvdG8iLCKuYmYiOjE1NDI4ODk2NzEsImV4cCI6MTU0MzQ5NDQ3MSwiaWF0IjoxNTQyODg5NjcxLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDE5MSJ9.5rOp3blnH2JepUcZxZdZ23T5DZrd4AgQnaWugJG_fGc";

    }
}
