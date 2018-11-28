using SideFrameWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using TokenHandler.Constants;
using TokenHandler.Utils;

namespace WSComptaPlus.Models
{
    /// <summary>
    /// This singleton class will gather all the web.config data needed. His duration equals the 
    /// duration of the Pool running the service. Therefore to fore a new reading we have to stop and start the IIS server.
    /// </summary>
    public class ApplicationData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(TokenKey.NormalLogsNameSpace);
        private static readonly log4net.ILog logInOut = log4net.LogManager.GetLogger(TokenKey.WebInOutLogsNameSpace);
        private static readonly Lazy<ApplicationData> lazy = new Lazy<ApplicationData>(() => new ApplicationData());

        private ERPDynamics.ClientConfiguration clientConfiguration = new ERPDynamics.ClientConfiguration();
        public  List<User> listUsersTokenAllowed = new List<User>() { };
        public  int TokenDaysLive;
        public  string PrivateTokenKey;
        public  string CodeRetourLoginOk;
        public  string CodeRetourLoginKo;
        public string LogConfigurationVerboseNormalNolog;

        public static ApplicationData Instance { get { return lazy.Value; } }
        private ApplicationData()
        {
            GetEnv();
            FillUpUsersTokenAllowed();
            GetOtheElementsFromTheConfig();
        }
        /// <summary>
        /// Gather subset of web.config elements
        /// </summary>
        private void GetOtheElementsFromTheConfig()
        {
            try
            {
                TokenDaysLive = Convert.ToInt32(GetEnvironmentConfig(TokenKey.TokenDaysLifeLabel));
                PrivateTokenKey = GetEnvironmentConfig(TokenKey.PrivateTokenKeyLabel);
                CodeRetourLoginOk = GetEnvironmentConfig(TokenKey.CodeRetourLoginOk);
                CodeRetourLoginKo = GetEnvironmentConfig(TokenKey.CodeRetourLoginKO);
                LogConfigurationVerboseNormalNolog = GetEnvironmentConfig(TokenKey.LogConfigurationVerboseNormalNolog);

            } catch (Exception ex) {
                log.Error(FormatMessages.getLogMessage(
                    this.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    TokenKey.NoMethodParams,
                    ex.ToString()));
                throw ex;
            }
        }
        #region Attribute - settings
        /// <summary>
        /// Obtenir l'environnement.
        /// </summary>
        private static string Environment => GetConfig(TokenKey.ConfigEnvironnementLabel, "");
        private static TypeEnvironment EnvironmentEnum => (TypeEnvironment)Enum.Parse(typeof(TypeEnvironment), GetConfig(TokenKey.ConfigEnvironnementEnumLabel, ""));
        /// <summary>
        /// Obtenir les informations de la configuration de l'environnement choisi
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static string GetConfig(string key, string defaultValue = "")
        {
            var v = System.Configuration.ConfigurationManager.AppSettings[key];
            return (!string.IsNullOrEmpty(v)) ? v : defaultValue;
        }
        /// <summary>
        /// Called to trace if config is well read.
        /// </summary>
        /// <param name="message"></param>
        public void ToLogInfo(string message="Empty") {;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("||||||||||||||||||||||||||||||||||||||||||||||||||||");
            sb.AppendLine(string.Format(" ApplicationData.LogInfo  ----> Message: {0}",message));
            sb.AppendLine("||||||||||||||||||||||||||||||||||||||||||||||||||||");
            sb.AppendLine();
            sb.AppendLine("Environment");
            sb.AppendLine("------------");
            sb.AppendLine(string.Format("Environment: {0} ", Environment));
            sb.AppendLine(string.Format(" TokenDaysLive: {0}" , TokenDaysLive));
            sb.AppendLine(string.Format(" PrivateTokenKey: {0}", PrivateTokenKey));
            sb.AppendLine(string.Format(" CodeRetourLoginOk: {0}", CodeRetourLoginOk));
            sb.AppendLine(string.Format(" CodeRetourLoginKo: {0}", CodeRetourLoginKo));
            sb.AppendLine(string.Format(" LogConfigurationVerboseNormalNolog: {0}", LogConfigurationVerboseNormalNolog));
            sb.AppendLine();
            sb.AppendLine("Liste des users dans la config");
            sb.AppendLine("------------------------------");
            foreach (var user in listUsersTokenAllowed) {
                sb.AppendLine(string.Format(" . User name: {0} ", user.Name));
            }
            sb.AppendLine();
            sb.AppendLine("clientConfiguration");
            sb.AppendLine("--------------------");
            sb.AppendLine(string.Format(" clientConfiguration.UriString: {0}" , clientConfiguration.UriString));
            sb.AppendLine(string.Format(" clientConfiguration.ActiveDirectoryResource: {0}" , clientConfiguration.ActiveDirectoryResource));
            sb.AppendLine(string.Format(" clientConfiguration.ActiveDirectoryTenant: {0}" , clientConfiguration.ActiveDirectoryTenant));
            sb.AppendLine(string.Format(" clientConfiguration.ActiveDirectoryClientAppId: {0}" , clientConfiguration.ActiveDirectoryClientAppId));
            sb.AppendLine(string.Format(" clientConfiguration.ActiveDirectoryClientAppSecret: {0}" , clientConfiguration.ActiveDirectoryClientAppSecret));
            sb.AppendLine("new values ...");
            sb.AppendLine(string.Format(" clientConfiguration.ActiveDirectoryTenantId: {0}" , clientConfiguration.ActiveDirectoryTenantId));
            sb.AppendLine(string.Format(" clientConfiguration.D365SalesUri: {0}" , clientConfiguration.D365SalesUri));
            sb.AppendLine(string.Format(" clientConfiguration.D365SalesClientId: {0}" , clientConfiguration.D365SalesClientId));
            sb.AppendLine(string.Format(" clientConfiguration.D365SalesClientKey: {0}" , clientConfiguration.D365SalesClientKey));
            sb.AppendLine(string.Format(" clientConfiguration.ServiceGroup: {0}" , clientConfiguration.ServiceGroup));
            sb.AppendLine(string.Format(" clientConfiguration.TLSVersion: {0}" , clientConfiguration.TLSVersion));
            sb.AppendLine();
            log.Info(sb.ToString());
            /*
        public  int TokenDaysLive;
        public  string PrivateTokenKey;
        public  string CodeRetourLoginOk;
        public  string CodeRetourLoginKo;
        public string LogConfigurationVerboseNormalNolog;
             */
        }
        /// <summary>
        /// Obtenir les informations sur l'environnement.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private static string GetEnvironmentConfig(string key, string defaultValue = "")
        {
            return GetConfig($"{Environment}.{key}");
        }
        private void GetEnv()
        {
            clientConfiguration = new ERPDynamics.ClientConfiguration()
            {
                UriString = GetEnvironmentConfig("UriString"),
                ActiveDirectoryResource = GetEnvironmentConfig("ActiveDirectoryResource"),
                ActiveDirectoryTenant = GetEnvironmentConfig("ActiveDirectoryTenant"),
                ActiveDirectoryClientAppId = GetEnvironmentConfig("ActiveDirectoryClientAppId"),
                ActiveDirectoryClientAppSecret = GetEnvironmentConfig("ActiveDirectoryClientAppSecret"),
                //added
                ActiveDirectoryTenantId = GetEnvironmentConfig("ActiveDirectoryTenantId"),
                D365SalesUri = GetEnvironmentConfig("D365SalesUri"),
                D365SalesClientId = GetEnvironmentConfig("D365SalesClientId"),
                D365SalesClientKey = GetEnvironmentConfig("D365SalesClientKey"),
                ServiceGroup = GetConfig("ServiceGroup"),
                TLSVersion = ""
            };
        }
        #endregion

        internal User UserExists(User user)
        {
            User userFound = listUsersTokenAllowed.Find(c => c.Name == user.Name && c.PassWord == user.PassWord);
            if (userFound != null)
            {
                log.Info(". UserExists() -> True");
                userFound.Exists = true;
            }
            else
            {
                log.Info(". UserExists() -> False");
                userFound.Exists = false;
            }
            return userFound;
        }
        public ERPDynamics.ClientConfiguration GetClientConfiguration() {
            return clientConfiguration;
        }
        private void ParseUsersFromConfigString(string usersString) {
        }
        private void FillUpUsersTokenAllowed()
        {
            //web.config not empty
            if (ConfigurationManager.AppSettings.Count > 0)
            {
                string usersAllowedToUseService = GetEnvironmentConfig("UsersAllowedToUseService");
                //we got the usersAllowedToUseService
                if (usersAllowedToUseService != null)
                {
                    ParseUsers(usersAllowedToUseService);
                }
                else
                {
                    Console.WriteLine("No customsetting1 application string");
                }
            }
        }
        /// <summary>
        /// "user1|pwuser1;user2|pwuser2;user3|pwuser3;
        /// </summary>
        /// <param name="usersAllowedToUseServiceString"></param>
        private void ParseUsers(string usersAllowedToUseServiceString) {
            string[] arr = usersAllowedToUseServiceString.Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            // convert to a Dictionary
            var dict = arr.Select(x => x.Split('|')).ToDictionary(i => i[0], i => i[1]);
            foreach (var part in dict) {
                listUsersTokenAllowed.Add(new User() {Name = part.Key, PassWord = part.Value });
            }
        }
    }
}