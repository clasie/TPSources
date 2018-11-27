using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.Enum;
using SideWsComptaPlus.Services;
using SideWsComptaPlus.Tools;
using System;
using System.Collections.Generic;


namespace SimulateurErpWs
{
    /// <summary>
    /// Instance de démarrage de l'application console.
    /// </summary>
    class Program
    {
        #region Initialisation
        static Program()
        {
            Environment = GetConfig("Environment");
        }
        /// <summary>
        /// Obtenir l'environnement.
        /// </summary>
        private static string Environment { get; set; }

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
        /// <returns></returns>
        private static string GetEnvironmentConfig(string key)
        {
            return GetConfig(string.Format("{0}.{1}", Environment, key));
        }

        #endregion

        /// <summary>
        /// Instance.
        /// </summary>
        private static void Main()
        {

            #region Initialisation config
            // Déterminer l'environnement de travail via paramètres config.
            var clientConfiguration = new ClientConfiguration()
            {
                UriString = GetEnvironmentConfig("UriString"),
                ActiveDirectoryResource = GetEnvironmentConfig("ActiveDirectoryResource"),
                ActiveDirectoryTenant = GetEnvironmentConfig("ActiveDirectoryTenant"),
                ActiveDirectoryClientAppId = GetEnvironmentConfig("ActiveDirectoryClientAppId"),
                ActiveDirectoryClientAppSecret = GetEnvironmentConfig("ActiveDirectoryClientAppSecret"),
                ActiveDirectoryTenantId = GetEnvironmentConfig("ActiveDirectoryTenantId"),
                ErpSalesUri = GetEnvironmentConfig("ErpSalesUri"),
                ErpSalesClientId = GetEnvironmentConfig("ErpSalesClientId"),
                ErpSalesClientKey = GetEnvironmentConfig("ErpSalesClientKey"),
                ServiceGroup = GetConfig("ServiceGroup"),
                ErpVersion = ""
            };
            #endregion

            #region Initialisation des listes

            //CashDiscERP
            var listCashDisc = new List<CashDiscERP>
            {
                    new CashDiscERP
                    {
                           CashDiscCode="TEST O",
                           Description="test cash discount",
                           MainAccountCustomer="403300",
                           MainAccountVendor="520200",
                           NumOfDays =5,
                           Percent = 0.5M,
                           CompanyName="FRRT",
                           StatusQuery = StatusQuery.Delete,
                           ERPOprNumber=Guid.NewGuid() },
                    new CashDiscERP
                    {
                           CashDiscCode="TEST X",
                           Description="test cash discount FRRT",
                           MainAccountCustomer="665000",
                           MainAccountVendor="765000",
                           NumOfDays =5,
                           Percent = 0.5M,
                           CompanyName="USMF",
                           StatusQuery = StatusQuery.Delete,
                           ERPOprNumber=Guid.NewGuid()   }

                 };

            //BusRelSegmentGroupERB
            var listBusRelSegmentGroupERB = new List<BusRelSegmentGroupERB>
            {
                    new BusRelSegmentGroupERB { SegmentId = "BBSeg", Description = "desc BSeg09", StatusQuery = StatusQuery.Create, ERPOprNumber = Guid.NewGuid() },
                    new BusRelSegmentGroupERB { SegmentId = "BBSeg10", Description = "desc BSeg10", StatusQuery = StatusQuery.Create, ERPOprNumber =Guid.NewGuid() },

             };
            #endregion

            //Méthode de liaison avec le service.
            var tableReferenceService = new TableReferenceService(clientConfiguration);

            #region Test Login avec recup token
            var responseLogin = tableReferenceService.Login( 
                new TokenHandler.Models.LoginRequest
                {
                    Username = "user1",
                    Password = "pwuser1" } );
            #endregion


            #region envoi CashDiscERP
            // Envoi CashDiscERP
            var responseCashDisc = tableReferenceService.CashDisc(listCashDisc);
            //// Réponse
            foreach (var element in responseCashDisc)
            {
                Console.Write("Response : code: {0} - Message{1}  D365 : {2} ERP : {3}\n",
                    element.Code, 
                    element.Message, 
                    element.DynamicsOprNumber, 
                    element.ErpOprNumber);
            }
            #endregion


            #region envoi BusRelSegmentGroup
            // Envoi BusRelSegmentGroup
            var responseBusRelSegmentGroupERB = tableReferenceService.BusRelSegmentGroup(listBusRelSegmentGroupERB);
            //// Réponse
            foreach (var element in responseBusRelSegmentGroupERB)
            {
                Console.Write("Response : code: {0} - Message{1}  D365 : {2} ERP : {3}\n",
                    element.Code,
                    element.Message,
                    element.DynamicsOprNumber,
                    element.ErpOprNumber);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
