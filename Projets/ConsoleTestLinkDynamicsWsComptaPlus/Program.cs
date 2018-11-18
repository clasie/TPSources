using ERPDynamics;
using LinkDynamicsWsComptaPlus;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestLinkDynamicsWsComptaPlus
{
    /// <summary>
    /// Console to test LinkDynamicsWsComptaPlus
    /// </summary>
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region catch env data
        private static string Environment
        {
            get { return GetConfig("Environment", ""); }
        }
        private static string GetConfig(string key, string defaultValue = "")
        {
            var v = ConfigurationManager.AppSettings[key];
            return (!string.IsNullOrEmpty(v)) ? v : defaultValue;
        }

        private static string GetEnvironmentConfig(string key, string defaultValue = "")
        {
            return GetConfig(string.Format("{0}.{1}", Environment, key));
        }
        #endregion

        static void Main(string[] args)
        {

            log.Info(string.Format("Method Called: {0}", MethodBase.GetCurrentMethod().Name));

            #region set ClientConfiguration
            ClientConfiguration clientConfiguration = null;
            try
            {
                clientConfiguration = new ClientConfiguration()
                {
                    UriString = GetEnvironmentConfig("UriString"),
                    ActiveDirectoryResource = GetEnvironmentConfig("ActiveDirectoryResource"),
                    ActiveDirectoryTenant = GetEnvironmentConfig("ActiveDirectoryTenant"),
                    ActiveDirectoryClientAppId = GetEnvironmentConfig("ActiveDirectoryClientAppId"),
                    ActiveDirectoryClientAppSecret = GetEnvironmentConfig("ActiveDirectoryClientAppSecret"),
                    ActiveDirectoryTenantId = GetEnvironmentConfig("ActiveDirectoryTenantId"),
                    D365SalesUri = GetEnvironmentConfig("D365SalesUri"),
                    D365SalesClientId = GetEnvironmentConfig("D365SalesClientId"),
                    D365SalesClientKey = GetEnvironmentConfig("D365SalesClientKey"),
                    ServiceGroup = GetConfig("ServiceGroup"),
                    TLSVersion = ""
                };
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error when 'new ClientConfiguration()' {0}, Inner exception: {1}", ex.Message, ex.InnerException));
                throw ex;
            }
            #endregion

            #region Set fake data and send it
            try
            {
                //CashDiscERP
                var listCashDisc = new List<CashDisc>
                {
                    new CashDisc
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
                    new CashDisc
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

                var listspCashDiscs = LinkDynamics.CallDynamicsCashDisc(clientConfiguration, listCashDisc);
                foreach (var element in listspCashDiscs) {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("listspCashDisc.Code : " + element.Code);
                    sb.AppendLine("listspCashDisc.Code : " + element.DynamicsOprNumber);
                    sb.AppendLine("listspCashDisc.Code : " + element.ERPOprNumber);
                    sb.AppendLine("listspCashDisc.Code : " + element.Message);
                    string message = sb.ToString();
                    Console.WriteLine(message);
                    log.Info(string.Format("Resultat loop on List<Response> {0}", message));
                }
            }
            catch (Exception ex)  
            {
                log.Error(string.Format("Error {0}, Inner exception: {1}", ex.Message, ex.InnerException));
                throw ex;
            }

            try
            {
                //BusRelSegmentGroupERB
                var listBusRelSegmentGroup = new List<ERPDynamics.BusRelSegmentGroup>
                {
                    new BusRelSegmentGroup { SegmentId = "BBSeg", Description = "desc BSeg09", StatusQuery = StatusQuery.Create, ERPOprNumber = Guid.NewGuid() },
                    new BusRelSegmentGroup { SegmentId = "BBSeg10", Description = "desc BSeg10", StatusQuery = StatusQuery.Create, ERPOprNumber =Guid.NewGuid() },

               };

                var listspBusRelSegmentGroup = LinkDynamics.CallDynamicsBusRelSegmentGroup(clientConfiguration, listBusRelSegmentGroup);
                foreach (var element in listspBusRelSegmentGroup)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("listspCashDisc.Code : " + element.Code);
                    sb.AppendLine("listspCashDisc.Code : " + element.DynamicsOprNumber);
                    sb.AppendLine("listspCashDisc.Code : " + element.ERPOprNumber);
                    sb.AppendLine("listspCashDisc.Code : " + element.Message);
                    string message = sb.ToString();
                    Console.WriteLine(message);
                    log.Info(string.Format("Resultat loop on List<Response>{0}", message));
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error {0}, Inner exception: {1}", ex.Message, ex.InnerException));
                throw ex;
            }
            #endregion
        }
    }
}
