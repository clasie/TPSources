using ERPDynamics;
using SideWsComptaPlus.Contracts;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WSComptaPlus.Models;
using Response = SideWsComptaPlus.ModelBusiness.Response;

namespace WSComptaPlus
{

    [ServiceContract]
    public interface IServiceComptaPlus
    {
        #region PCMN Interface 01 - COM03
        /// <summary>
        /// PCMN.
        /// </summary>
        /// <param name="datapcmn"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/syncPcmnList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        // List<Response> PcmnObject(List<PcmnIn01> datapcmn);
        #endregion

        #region Taxe Interface 36.1 à 36.3 - COM09
        /// <summary>
        /// Groupe de taxe. Interface 36.1
        /// </summary>
        /// <param name="datataxGroup"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(
        //    Method = "POST", 
        //    UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/syncTaxGroupList", 
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, 
        //    ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxGroupObject(List<TaxGroupIn361> datataxGroup);

        /// <summary>
        /// Groupe de taxe article. Interface 36.2
        /// </summary>
        /// <param name="datataxItemGroup"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/syncTaxItemGroupList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxItemGroupObject(List<TaxItemGroupIn362> datataxItemGroup);

        /// <summary>
        /// Code de taxe. Interface 36.3
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/syncTaxCodeList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxCodeObject(List<TaxCodeIn363> datataxCode);

        /// <summary>
        /// Code de taxe. Interface 36.4
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncTaxCodeTaxGroupList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxCodeTaxGroupObject(List<TaxCodeTaxGroupIn364> datataxCode);
        ///// <summary>
        /// Code de taxe. Interface 36.5
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncTaxCodeTaxItemGroupList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxCodeTaxItemGroupObject(List<TaxCodeTaxItemGroupIN365> datataxCode);
        ///// <summary>
        /// Code de taxe. Interface 36.6
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncTaxCodeValueList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxCodeValueListObject(List<TaxCodeValueIN366> datataxCode);
        ///// <summary>
        /// Code de taxe. Interface 36.7
        /// </summary>
        /// <param name="datataxCode"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncTaxCodeLanguageTxtList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> TaxCodeLanguageTxtObject(List<TaxCodeLanguageTxtIN367> datataxCode);
        #endregion

        #region Dimension Analytique Interface 03 - COM05
        /// <summary>
        /// Setup des dimensions des comptes Analytique. Interface 03
        /// </summary>
        /// <param name="dataDimensionAttributeSetup"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/syncDimensionAttributeSetupList", BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> DimensionAttributeSetupObject(List<DimensionAttributeSetupIn03> dataDimensionAttributeSetup);

        /// <summary>
        /// Les dimensions des comptes analytique. Interface 03
        /// </summary>
        /// <param name="dataDimensionAttributeValue"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/syncDimensionAttributeValueList",
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> DataDimensionAttributeValueObject(List<DimensionAttributeValueIn03> dataDimensionAttributeValue);


        #endregion

        #region Journaux Interface 43 - COM23
        /// <summary>
        /// Les Journaux. Interface 43
        /// </summary>
        /// <param name="dataLedgerJournalName"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncLedgerJournalNameList",
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> LedgerJournalNameObject(List<LedgerJournalNameIn43> dataLedgerJournalName);
        #endregion


        #region Informations générales
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "info/ws", ResponseFormat = WebMessageFormat.Json)]
        WsInfoModel GetInfoWebService();

        #endregion


        #region Périodes interface 22 - COM
        /// <summary>
        /// Les périodes Fiscales.
        /// </summary>
        /// <param name="dataPeriod"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncFiscalCalendarPeriod",
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> PeriodObject(List<FiscalCalendarPeriodIN22> dataPeriod);
        #endregion

        #region Journaux Vente interface 34 - COM
        /// <summary>
        /// Les périodes Fiscales.
        /// </summary>
        /// <param name="dataJnlVente"></param>
        /// <returns></returns>
        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    UriTemplate = "api/services/Erp_Dynamics/DynamicsTableReferenceService/SyncVendorLedgerJournal",
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //List<Response> VendorLedgerJournalObject(List<VendorLedgerJournalIN34> dataJnlVente);
        #endregion


        // Interrogation vers D365
        #region Segment
        /// <summary>
        /// PCMN.
        /// </summary>
        /// <param name="dataSegment"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DynamicsTableReferenceService/syncSegmentList", BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Response> SegmentD365Object(List<BusRelSegmentGroup> dataSegment);
        #endregion

        #region syncCashDisc
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="dataJnlVente"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "api/services/NVL_Dynamics_ERP/NVL_ERPTableReferenceService/syncCashDisc",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ERPDynamics.Response> CashDisc(List<CashDiscERP> data);//test git
        #endregion

        #region BusRelSegmentGroup
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="dataJnlVente"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "api/services/NVL_Dynamics_ERP/NVL_ERPTableReferenceService/syncBusRelSegmentGroup",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<ERPDynamics.Response> BusRelSegmentGroup(List<BusRelSegmentGroupERB> data);
        #endregion
    }
}
