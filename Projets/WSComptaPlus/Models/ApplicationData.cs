using SideFrameWork.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WSComptaPlus.Models
{
    /// <summary>
    /// This singleton class will gather all the web.config data needed. His duration equals the 
    /// duration of the Pool running the service. Therefore to fore a new reading we have to stop and start the IIS server.
    /// </summary>
    public class ApplicationData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ERPDynamics.ClientConfiguration clientConfiguration = new ERPDynamics.ClientConfiguration();
        private static readonly Lazy<ApplicationData> lazy = new Lazy<ApplicationData>(() => new ApplicationData());
        public List<User> listUsersTokenAllowed = new List<User>() { };

        public static ApplicationData Instance { get { return lazy.Value; } }

        private ApplicationData()
        {
            log.Info("Before ooooooooooooo->> ApplicationData.Instance -> in ApplicationData ");
            //GetEnv();
            FillUpUsersTokenAllowed();
        }
        #region Attribute - settings
        /// <summary>
        /// Obtenir l'environnement.
        /// </summary>
        private static string Environment => GetConfig("Environment", "");
        private static TypeEnvironment EnvironmentEnum => (TypeEnvironment)Enum.Parse(typeof(TypeEnvironment), GetConfig("EnvironmentEnum", ""));
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
            log.Info("Before ooooooooooooo->>ParseUsers 1.3 " + usersAllowedToUseServiceString);
            string[] arr = usersAllowedToUseServiceString.Split(new[] { ';' },StringSplitOptions.RemoveEmptyEntries);
            // convert to a Dictionary
            var dict = arr.Select(x => x.Split('|')).ToDictionary(i => i[0], i => i[1]);
            foreach (var part in dict) {
                listUsersTokenAllowed.Add(new User() {Name = part.Key, PassWord = part.Value });
            }
            foreach (var user in listUsersTokenAllowed) {
                log.Info(string.Format(" ---> User name: {0}, User pw: {1} ", user.Name, user.PassWord));
            }

        }
    }
}