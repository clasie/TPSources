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
        //enabled for 100 days (from 11/29/2018 to + 100 days)
        public const string GeneratedKeyToTest = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIxIiwibmJmIjoxNTQzNDg4MTE0LCJleHAiOjE1NDQwOTI5MTQsImlhdCI6MTU0MzQ4ODExNCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDE5MSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEifQ.3z1BdSbliYT1GTdNZvwknm9giKNidwNG9Y4nPjrhqG4";
        public const string GeneratedKeyToTestWithHeader = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIxIiwibmJmIjoxNTQzNDg4MTE0LCJleHAiOjE1NDQwOTI5MTQsImlhdCI6MTU0MzQ4ODExNCwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDE5MSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAxOTEifQ.3z1BdSbliYT1GTdNZvwknm9giKNidwNG9Y4nPjrhqG4";
        //Prefix expected in header
        public const string PrefixSetByTheCallerBeforeTheKey = "Bearer ";
        public const string MessageTokenForUser = "New token created";
        //public const string CodeUserExists = "10000";
        //Some labels
        public const string MethodCallLabel = "Method Called:";
        //Error messages
        public const string ServicErrorMinimalMessage = "Error occured on service";     
        //public const string CodeUnknownUser = "10001";
        public const string MessageNoTokenForUnknownUser = "The user is unknown";
        public const string TokenInvalid = "Token not valid.";
        public const string TokenNotFound = "Token not found.";
        public const string CustomExceptionLabel = "Custom exception";
        public const string NoTokenCreatedLabel = "No token created";
        public const string TokenRefusedLabel = "Token refused";
        public const string TokenIssue = "Token Issue";
        public const string NoMethodParams = "No method param";
    }
}
