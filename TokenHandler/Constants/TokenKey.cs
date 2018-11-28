using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Constants
{
    public static class TokenKey
    {
        //log4net namespaces
        public const string NormalLogsNameSpace = "NormalLogs"; 
        public const string WebInOutLogsNameSpace = "WebInOutLogs";
        public static string TokenAccessNameSpace = "TokenAccessLogs";
        public const string TokenVerification = "Token verification";
        //log4net messages
        public const string IN = "IN";
        public const string OUT = "OUT";
        //Config when creating a Token
        public const int TokenDaysLive = 7;
        public const string Issuer = "http://localhost:50191";//No need for real urls, just well formated ones
        public const string Audience = "http://localhost:50191";//No need for real urls, just well formated ones
        public const string HeaderTokenToUse = "Authorization";
        //Expected place to find the header
        public const int ExpectedPlaceToFindHeader = 0;
        //Expected prefix for the token in the header
        public const string TokenPrefix = "^Bearer ";
        public const string TokenPrefixRaw = "Bearer ";
        //Private token key
        public const string PrivateKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        //Generated Token for test purposes
        public const string GeneratedKeyToTest = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Inh4eCIsIm5iZiI6MTU0Mjk3MzY0NywiZXhwIjoxNTQzNTc4NDQ3LCJpYXQiOjE1NDI5NzM2NDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIn0.pbEv8JYFVmp74pm7-XsBsPSLjpdzdGrf5Vc5451wM-I";
        public const string GeneratedKeyToTestWithHeader = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Inh4eCIsIm5iZiI6MTU0Mjk3MzY0NywiZXhwIjoxNTQzNTc4NDQ3LCJpYXQiOjE1NDI5NzM2NDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIn0.pbEv8JYFVmp74pm7-XsBsPSLjpdzdGrf5Vc5451wM-I";
        //Prefix expected in header
        public const string PrefixSetByTheCallerBeforeTheKey = "Bearer ";
        public const string MessageTokenForUser = "New token created";
        public const string CodeUserExists = "10000";
        //Some labels
        public const string MethodCallLabel = "Method Called:";
        //Error messages
        public const string ServicErrorMinimalMessage = "Error occured on service";     
        public const string CodeUnknownUser = "10001";
        public const string MessageNoTokenForUnknownUser = "No token, the user is unknown";
        public const string TokenInvalid = "Token not valid.";
        public const string TokenNotFound = "Token not found.";
        public const string CustomExceptionLabel = "Custom exception";
        public const string NoTokenCreatedLabel = "No token created";
        public const string TokenRefusedLabel = "Token refused";
        public const string TokenIssue = "Token Issue";
    }
}
