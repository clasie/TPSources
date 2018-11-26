using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSComptaPlus.Models
{
    /// <summary>
    /// This singleton class will gather all the web.config data needed. His duration equals the 
    /// duration of the Pool running the service. Therefore to fore a new reading we have to stop and start the IIS server.
    /// </summary>
    public class ApplicationData
    {
        private static readonly Lazy<ApplicationData> lazy =
            new Lazy<ApplicationData>(() => new ApplicationData());

        public static ApplicationData Instance { get { return lazy.Value; } }

        private ApplicationData()
        {}
        private List<User> listUsers = new List<User>() { };
        public void ReadConfigFile() {
            System.Configuration.Configuration rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
            if (rootWebConfig1.AppSettings.Settings.Count > 0)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                    rootWebConfig1.AppSettings.Settings["customsetting1"];
                if (customSetting != null)
                    Console.WriteLine("customsetting1 application string = \"{0}\"",
                        customSetting.Value);
                else
                    Console.WriteLine("No customsetting1 application string");
            }
        }
    }
}