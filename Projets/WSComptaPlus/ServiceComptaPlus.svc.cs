//-----------------------------------------------------------------------------------
//
//  Application     :   Gestion des méthodes du Web Services (partie serveur)
//
//  Langage         :   C# 7.0 sous Visual Studio 2017 Community
//
//  FrameWork       :   4.6.1.1.
//
//  Projet          :   DLL FrameWorkSide (informations communes)
//
//  Date            :   07/09/2018
//
//-----------------------------------------------------------------------------------
//
//  Détail Release  :   Version VS | Version C# | Version FrameWork | Version release
//
//
//
//  V.17.07.461.00          CMA     Démarrage.
//
//
//-----------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using ERPDynamics;
using SideFrameWork.Enum;
using SideWsComptaPlus.Contracts;
using WSComptaPlus.Models;
//using SideClassWsComptaPlus.ClassWs;
using SideWsComptaPlus.ModelBusiness;
using Response = SideWsComptaPlus.ModelBusiness.Response;
using LinkDynamicsWsComptaPlus;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace WSComptaPlus
{


    /// <summary>
    /// Service :   Gestion des appels et demandes pour la comptabilité Thomas & Piron (Compta Plus)
    /// </summary>
    public class ServiceComptaPlus : IServiceComptaPlus
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        private ERPDynamics.ClientConfiguration GetEnv() {
            return new ERPDynamics.ClientConfiguration()
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

        #region membres
        #endregion

        #region PCMN Interface 01 - COM03
        /// <inheritdoc />
        /// <summary>
        /// Recevoir les informations concernant soit la création, modification ou
        /// suspension d'un ou plusieurs comptes du PCMN.
        /// </summary>
        /// <param name = "datapcmn" ></ param >
        /// < returns > Si la création, modification ou suspension c'est bien déroulée - ResponseData</returns>
        /// <remarks>D365 envoi l'information</remarks>
        //public List<Response> PcmnObject(List<PcmnIn01> datapcmn)
        //{
        //    return ClsPcmnIn01.Execute(datapcmn, TypeEnvironment.Dev);
        //}
        #endregion

        #region Groupe de taxe Interface 36.1 - 36.2 - 36.3 - 36.4 -36.5 - 36.6 - 36.7 - COM09
        /// <inheritdoc />
        /// <summary>
        /// Recevoir les informations concernant soit la création, modification ou
        /// suspension d'un ou plusieurs groupe de taxe.
        /// </summary>
        /// <param name="datataxGroup"></param>
        /// <returns>Si la création, modification ou suspension c'est bien déroulée - ResponseData</returns>
        /// <remarks>D365 envoi l'information</remarks>
        //public List<Response> TaxGroupObject(List<TaxGroupIn361> datataxGroup)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxGroup(datataxGroup, TypeEnvironment.Dev);
        //}
        /// <inheritdoc />
        /// <summary>
        /// Recevoir les informations concernant soit la création, modification ou
        /// suspension d'un ou plusieurs groupe de taxe article.
        /// </summary>
        /// <param name="datataxItemGroup"></param>
        /// <returns>Si la création, modification ou suspension c'est bien déroulée - ResponseData</returns>
        /// <remarks>D365 envoi l'information</remarks>
        //public List<Response> TaxItemGroupObject(List<TaxItemGroupIn362> datataxItemGroup)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxGroupArticle(datataxItemGroup, TypeEnvironment.Dev);
        //}
        /// <summary>
        /// Recevoir les informations concernant soit la création, modification ou
        /// suspension d'un ou plusieurs code de taxe.
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns>Si la création, modification ou suspension c'est bien déroulée - ResponseData</returns>
        /// <remarks>D365 envoi l'information</remarks>
        //public List<Response> TaxCodeObject(List<TaxCodeIn363> datataxCode)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxGroupCode(datataxCode, TypeEnvironment.Dev);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //public List<Response> TaxCodeTaxGroupObject(List<TaxCodeTaxGroupIn364> datataxCode)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxCodeTaxGroup(datataxCode, TypeEnvironment.Dev);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //public List<Response> TaxCodeTaxItemGroupObject(List<TaxCodeTaxItemGroupIN365> datataxCode)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxCodeTaxItemGroup(datataxCode, TypeEnvironment.Dev);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //public List<Response> TaxCodeValueListObject(List<TaxCodeValueIN366> datataxCode)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxCodeValue(datataxCode, TypeEnvironment.Dev);
        //}
        /// <summary>
        ///
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //public List<Response> TaxCodeLanguageTxtObject(List<TaxCodeLanguageTxtIN367> datataxCode)
        //{
        //    return ClsTaxGroupIn36.ExecuteTaxCodeLanguageTxt(datataxCode, TypeEnvironment.Dev);
        //}
        #endregion

        #region Dimension Analytique Interface 03 - COM05
        /// <inheritdoc />
        /// <summary>
        /// Recevoir les informations concernant le setup des dimensions analytique (pour une nouvelle société).
        /// </summary>
        /// <param name="dataDimensionAttributeSetup"></param>
        /// <returns>Si la création c'est bien déroulée - ResponseData</returns>
        /// <remarks>D365 envoi l'information</remarks>
        //public List<Response> DimensionAttributeSetupObject(List<DimensionAttributeSetupIn03> dataDimensionAttributeSetup)
        //{
        //    return ClsDimensionAttributeIn03.ExecuteAxeAnalytique(dataDimensionAttributeSetup, TypeEnvironment.Dev);
        //}
        /// <inheritdoc />
        /// <summary>
        /// Recevoir les informations concernant soit la création, modification ou
        /// suspension d'une ou plusieurs dimensions analytique.
        /// </summary>
        /// <param name="dataDimensionAttributeValue"></param>
        /// <returns>Si la création, modification ou suspension c'est bien déroulée - ResponseData</returns>
        /// <remarks>D365 envoi l'information</remarks>
        //public List<Response> DataDimensionAttributeValueObject(List<DimensionAttributeValueIn03> dataDimensionAttributeValue)
        //{
        //    return ClsDimensionAttributeIn03.ExecuteCompteAnalytique(dataDimensionAttributeValue, TypeEnvironment.Dev);
        //}
        #endregion

        #region Les journaux  Interface 43 - COM23
        //public List<Response> LedgerJournalNameObject(List<LedgerJournalNameIn43> dataLedgerJournalName)
        //{
        //    return ClsLedgerJournalNameIn43.ExecuteJournaux(dataLedgerJournalName, TypeEnvironment.Dev);
        //}
        #endregion

        #region Informations sur le Web Service
        /// <summary>
        /// Test du Web Service Compta Plus
        /// </summary>
        /// <returns></returns>
        public WsInfoModel  GetInfoWebService()
        {
            log.Info(string.Format("WEB 2.0 Method Called: {0}", MethodBase.GetCurrentMethod().Name));

            return new WsInfoModel()
            {
                Id = Guid.NewGuid(),
                NomWs = "Web Services ComptaPlus 1",
                DescriptionWs = "Liaison entre Dynamics 365 et le ERP de chez Thomas & Piron",
                CopyRightWs = "Copyright ©" + DateTime.Now.Year + " Side Sa",
                EtatWs = "Développement (51180)"
            };
        }
        #endregion

        //public List<Response> VendorLedgerJournalObject(List<VendorLedgerJournalIN34> dataJnlVente)
        //{
        //    return ClsLedgerJournalIn34.ExecuteVendorLedgerJournalIn34(dataJnlVente, TypeEnvironment.Dev);
        //}

        #region Interrogation vers D365

        #region Segment
        public List<Response> SegmentD365Object(List<BusRelSegmentGroup> dataSegment)
        {
            throw new NotImplementedException();
        }
        #endregion


        //public List<Response> PeriodObject(List<FiscalCalendarPeriodIN22> dataPeriod)
        //{
        //    return ClsPeriodIn22.ExecutePeriod(dataPeriod, TypeEnvironment.Dev);
        //}

        //public List<Response> VendorLedgerJournalObject(List<LedgerJournalTransIN34> dataJnlVente)
        //{
        //    throw new NotImplementedException();
        //}

        #region CashDisc
        public List<ERPDynamics.Response> CashDisc(List<CashDiscERP> data)
        {
            log.Info(string.Format("WEB 1.0 Method Called: {0}", MethodBase.GetCurrentMethod().Name));
            return LinkDynamics.CallDynamicsCashDisc(GetEnv(), CashDiscERP2CashDisc(data));//envoyer vers AZURE
        }
        #endregion

        #region BusRelSegmentGroup
        public List<ERPDynamics.Response> BusRelSegmentGroup(List<BusRelSegmentGroupERB> data)
        {
            log.Info(string.Format("Method Called: {0}", MethodBase.GetCurrentMethod().Name));
            return LinkDynamics.CallDynamicsBusRelSegmentGroup(GetEnv(), BusRelSegmentGroupERB2BusRelSegmentGroup(data));//envoyer vers AZURE
        }
        #endregion

        #endregion

        #region Mapping CashDiscERP2CashDisc
        private List<CashDisc> CashDiscERP2CashDisc(List<CashDiscERP> listCashDiscERP) {

            log.Info(string.Format("IN CashDiscERP2CashDisc, listCashDiscERP: {0}", listCashDiscERP.Count));

            List<CashDisc> listCashDisc = listCashDiscERP.Select(p => new CashDisc() {
                CashDiscCode = p.CashDiscCode,
                Description = p.Description,
                ERPOprNumber = p.ERPOprNumber,
                NumOfDays = p.NumOfDays,
                StatusQuery = p.StatusQuery,
                Percent = p.Percent,
                MainAccountCustomer = p.MainAccountCustomer,
                MainAccountVendor = p.MainAccountVendor
            }).ToList();

            return listCashDisc;
        }
        #endregion

        #region Mapping BusRelSegmentGroupERB2BusRelSegmentGroup
        private List<BusRelSegmentGroup> BusRelSegmentGroupERB2BusRelSegmentGroup(List<BusRelSegmentGroupERB> listBusRelSegmentGroupERB)
        {
            List<BusRelSegmentGroup> listBusRelSegmentGroup = listBusRelSegmentGroupERB.Select(p => new BusRelSegmentGroup()
            {
               Description = p.Description,
                ERPOprNumber = p.ERPOprNumber,
                SegmentId = p.SegmentId,
                StatusQuery = p.StatusQuery
            }).ToList();
            return listBusRelSegmentGroup;
        }
        #endregion
    }
}
