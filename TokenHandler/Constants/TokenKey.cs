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
        //config env
        public const string ConfigEnvironnementLabel = "Environment";
        public const string ConfigEnvironnementEnumLabel = "EnvironmentEnum";
        public const string CodeRetourLoginOk = "CodeRetourLoginOk";
        public const string CodeRetourLoginKO = "CodeRetourLoginKO";
        public const string LogConfigurationVerboseNormalNolog = "LogConfiguration_Verbose_Normal_Nolog";
        public const string Verbose = "Verbose";
        public const string Normal = "Normal";
        public const string NoLog = "NoLog";
        //Config when creating a Token
        public const string TokenDaysLifeLabel = "TokenDaysLife";
        public const string PrivateTokenKeyLabel = "PrivateTokenKey"; 
        public const string Issuer = "http://localhost:50191";//No need for real urls, just well formated ones
        public const string Audience = "http://localhost:50191";//No need for real urls, just well formated ones
        public const string HeaderTokenToUse = "Authorization";
        //Expected place to find the header
        public const int ExpectedPlaceToFindHeader = 0;
        //Expected prefix for the token in the header
        public const string TokenPrefix = "^Bearer ";
        public const string TokenPrefixRaw = "Bearer ";
        //Generated Token for test purposes
        public const string GeneratedKeyToTest = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Inh4eCIsIm5iZiI6MTU0Mjk3MzY0NywiZXhwIjoxNTQzNTc4NDQ3LCJpYXQiOjE1NDI5NzM2NDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIn0.pbEv8JYFVmp74pm7-XsBsPSLjpdzdGrf5Vc5451wM-I";
        public const string GeneratedKeyToTestWithHeader = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Inh4eCIsIm5iZiI6MTU0Mjk3MzY0NywiZXhwIjoxNTQzNTc4NDQ3LCJpYXQiOjE1NDI5NzM2NDcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMTkxIn0.pbEv8JYFVmp74pm7-XsBsPSLjpdzdGrf5Vc5451wM-I";
        //Prefix expected in header
        public const string PrefixSetByTheCallerBeforeTheKey = "Bearer ";
        public const string MessageTokenForUser = "New token created";
        //public const string CodeUserExists = "10000";
        //Some labels
        public const string MethodCallLabel = "Method Called:";
        //Error messages
        public const string ServicErrorMinimalMessage = "Error occured on service";     
        //public const string CodeUnknownUser = "10001";
        public const string MessageNoTokenForUnknownUser = "No token, the user is unknown";
        public const string TokenInvalid = "Token not valid.";
        public const string TokenNotFound = "Token not found.";
        public const string CustomExceptionLabel = "Custom exception";
        public const string NoTokenCreatedLabel = "No token created";
        public const string TokenRefusedLabel = "Token refused";
        public const string TokenIssue = "Token Issue";
        public const string NoMethodParams = "No method param";
    }
}
