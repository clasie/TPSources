using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Constants
{
    public static class TokenKey
    {
        //Private token key -> to be incrypted!
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
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Inh4eCIsIm5iZiI6MTU0Mjk3MzY0NywiZXhwIjoxNTQzNTc4NDQ3LCJpYXQiOjE1NDI5NzM2NDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIn0.pbEv8JYFVmp74pm7-XsBsPSLjpdzdGrf5Vc5451wM-I";
        public const string GeneratedKeyToTestWithHeader =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Inh4eCIsIm5iZiI6MTU0Mjk3MzY0NywiZXhwIjoxNTQzNTc4NDQ3LCJpYXQiOjE1NDI5NzM2NDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIn0.pbEv8JYFVmp74pm7-XsBsPSLjpdzdGrf5Vc5451wM-I";
        public const string TokenInvalid = "Token not valid, please log in before using the services.";
        public const string TokenNotFound = "Token not found, please log in before using the services.";
        public const string MethodCallLabel = "Method Called:";
        public const string CustomExceptionLabel = "Custom exception";
        public const string NoTokenCreatedLabel = "No token created";
        //Expected prefix for the token in the header
        public const string TokenPrefix = "^Bearer ";
        public const string TokenPrefixRaw = "Bearer ";
        //Config when creating a Token
        public const int TokenDaysLive = 7;
        public const string Issuer = "http://localhost:50191";
        public const string Audience = "http://localhost:50191";
        public const string HeaderTokenToUse = "Authorization";
        
    }
}
