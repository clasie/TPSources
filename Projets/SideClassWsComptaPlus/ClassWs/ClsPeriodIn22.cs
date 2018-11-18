// ***********************************************************************************
//
//      Solution            :   WebServiceComptaPlus
//      Projet              :   SideClassWsComptaPlus
//
//      Titre               :   Plan de comptes modèle normalisé - Interface 01
//      Description         :   -
//
//      Démarrage           :   25-09-2018
//      Version langage C#  :   4.0
//
//      Assembly            :   4.5.2 (Version de D365)
//
//
// ***********************************************************************************
//
//      Client              :   Thomas & Piron
//      Projet métier       :   Compta Plus
//
//      Manager projet      :   François Piret
//      Chef de Projet      :   Laurent Mathieu
//
//      CopyRight           :   Side sa
//
// ***********************************************************************************

using System;
//using SideClassWsComptaPlus.System;
using SideFrameWork.Enum;
using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.ModelBusiness;
using System.Collections.Generic;

namespace SideClassWsComptaPlus.ClassWs
{
    /// <summary>
    /// Class    :
    /// </summary>
    /// <returns></returns>
    /// <remarks>Interface 22 - DC-IN - COM</remarks>
    public class ClsPeriodIn22
    {
        /// <summary>
        /// Method  :   un ou plusieurs comptes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn22">Obtient ou Définit la liste des comptes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface  - DC-IN - COM</remarks>
        /// <example></example>
        public static List<Response> ExecutePeriod(List<FiscalCalendarPeriodIN22> dDataIn22, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn22)
            {
                ListResponse.Add(new Response
                {
                    Code = "0",
                    Message = "",
                    ErpOprNumber = Guid.NewGuid(),
                    DynamicsOprNumber = element.DynamicsOprNumber
                });
            }

            return ListResponse;
        }
    }
}
