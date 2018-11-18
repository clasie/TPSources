//-----------------------------------------------------------------------------------
//
//  Application     :   Simulateur du Web Service du ERP TP
//
//  Langage         :   C# 7.0 sous Visual Studio 2017
//
//  FrameWork       :   4.6.1.1.
//
//  Projet          :   DLL SideClientWebServiceComptaPlus
//
//  Date            :   07/09/2018
//
//  Copyright       :   Side SA - 2018
//
//  Client          :   Thomas & Piron
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

using FrameWorkSide.DataBase.WebServices;
using FrameWorkSide.Models.WebServices.Json;
using System.Collections.ObjectModel;

namespace SideClientWebServiceComptaPlus.GetWebService
{
    /// <summary>
    /// Code Base   :   ERP donne les informations sur un ou des segment(s).
    /// nouveau, modifier ou supprimer
    /// </summary>
    public class MethodSegmentGetErp
    {
        /// <summary>
        /// Method  :   ERP donne les informations sur un segment.
        /// </summary>
        /// <param name="urlBase">Définit URL de base</param>
        /// <returns>Les données du Segment ainsi que le mode de travail du Query</returns>
        public static SegmentModelJson RunElement(string urlBase)
        {
            var valueReturn = new WebServiceContext<SegmentModelJson>(
                urlBase).GetResponse("segment", "element", HttpMethod.GET);

            return string.IsNullOrEmpty(valueReturn.ToString())
                ? null
                : FrameWorkSide.Helpers.JsonHelp.JsonDeserialize<SegmentModelJson>(valueReturn.ToString());
        }

        /// <summary>
        /// Method  :   ERP donne les informations sur une liste de segment.
        /// </summary>
        /// <param name="urlBase">Définit URL de base</param>
        /// <returns>Les données d'une liste de Segment ainsi que le mode de travail du Query</returns>
        public static ObservableCollection<SegmentModelJson> RunList(string urlBase)
        {
            var valueReturn = new WebServiceContext<ObservableCollection<SegmentModelJson>>(
                urlBase).GetResponse("segment", "list", HttpMethod.GET);

            return string.IsNullOrEmpty(valueReturn.ToString())
                ? null
                : FrameWorkSide.Helpers.JsonHelp.JsonDeserialize<ObservableCollection<SegmentModelJson>>(valueReturn.ToString());
        }

        #region Pour Test

        public static ObservableCollection<SegmentModelJson> RunList1000(string urlBase)
        {
            var valueReturn = new WebServiceContext<ObservableCollection<SegmentModelJson>>(
                urlBase).GetResponse("segment", "list1000", HttpMethod.GET);

            return string.IsNullOrEmpty(valueReturn.ToString())
                ? null
                : FrameWorkSide.Helpers.JsonHelp.JsonDeserialize<ObservableCollection<SegmentModelJson>>(valueReturn.ToString());

        }

        public static ObservableCollection<SegmentModelJson> RunList100000(string urlBase)
        {
            var valueReturn = new WebServiceContext<ObservableCollection<SegmentModelJson>>(
                urlBase).GetResponse("segment", "list100000", HttpMethod.GET);

            return string.IsNullOrEmpty(valueReturn.ToString())
                ? null
                : FrameWorkSide.Helpers.JsonHelp.JsonDeserialize<ObservableCollection<SegmentModelJson>>(
                    valueReturn.ToString());
        }

        #endregion

        
    }
}
