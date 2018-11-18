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

using System.Collections.Generic;
using FrameWorkSide.DataBase.WebServices;
using FrameWorkSide.Models.WebServices.Json;

namespace SideClientWebServiceComptaPlus.GetWebService
{
    /// <summary>
    /// Code de base    :   Appel aux informations du Web Service (Test)
    /// </summary>
    public class MethodInfoWebServices
    {
        public static WebServiceModelJson Run(string urlBase)
        {
            var valueReturn = new WebServiceContext<WebServiceModelJson>(
                urlBase).GetResponse("info", "ws", HttpMethod.GET);

            return string.IsNullOrEmpty(valueReturn.ToString())
                ? null
                : FrameWorkSide.Helpers.JsonHelp.JsonDeserialize<WebServiceModelJson>(valueReturn.ToString());

        }
    }
}
