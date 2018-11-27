using ERPDynamics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkDynamicsWsComptaPlus
{
    public static class LinkDynamics
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(TokenHandler.Constants.TokenKey.NormalLogsNameSpace);
        private static readonly log4net.ILog logInOut = log4net.LogManager.GetLogger(TokenHandler.Constants.TokenKey.WebInOutLogsNameSpace);
        public static object TokenKey { get; private set; }

        #region CallDynamicsCashDisc
        /// <summary>
        /// We call the Dynamics Azure web service for CashDisc
        /// </summary>
        /// <param name="clientConfiguration"></param>
        /// <param name="listCashDisk"></param>
        /// <returns></returns>
        public static List<Response> CallDynamicsCashDisc(ClientConfiguration clientConfiguration, List<CashDisc> listCashDisk)
        {

            log.Info(string.Format("Method Called: {0}", MethodBase.GetCurrentMethod().Name));
            try
            {
                TableReferenceService tableReferenceService = new TableReferenceService(clientConfiguration);
                return tableReferenceService.syncCashDiscList(listCashDisk);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error {0}, Inner exception: {1}", ex.Message, ex.InnerException));
                throw ex;
            }
        }
        #endregion

        #region CallDynamicsBusRelSegmentGroup
        /// <summary>
        /// We call the Dynamics Azure web service for BusRelSegmentGroup
        /// </summary>
        /// <param name="clientConfiguration"></param>
        /// <param name="listBusRelSegmentGroup"></param>
        /// <returns></returns>
        public static List<Response> CallDynamicsBusRelSegmentGroup(ClientConfiguration clientConfiguration, List<BusRelSegmentGroup> listBusRelSegmentGroup)
        {
            log.Error(string.Format("Method Called: {0}", MethodBase.GetCurrentMethod().Name));
            try
            {
                TableReferenceService tableReferenceService = new TableReferenceService(clientConfiguration);
                return tableReferenceService.syncBusRelSegmentGroupList(listBusRelSegmentGroup);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Error {0}, Inner exception: {1}", ex.Message, ex.InnerException));
                throw ex;

            }
        }
        #endregion
    }
}
