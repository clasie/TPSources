// ***********************************************************************************
//
//      Solution            :   Liaison avec WebServiceComptaPlus et SideClassWsComptaPlus
//      Projet              :   SideClassWsComptaPlus
//
//      Titre               :   Plan de comptes modèle normalisé - Interface 01
//      Description         :   Application visant directement la base de données du métier
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
//using SideClassWsComptaPlus.System;
//using SideClassWsComptaPlus.Tools;
using SideFrameWork.Enum;
using SideFrameWork.GenericListsTP;
using SideFrameWork.Models;
using SideFrameWork.Models.TP;
using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.ModelBusiness;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static SideFrameWork.Utils.SideConfiguration;

namespace SideClassWsComptaPlus.ClassWs
{
    /// <summary>
    /// Class    :   Plan de compte modèle normalisé.
    /// </summary>
    /// <returns></returns>
    /// <remarks>Interface 01 - DC-IN02 - COM03</remarks>
    public class ClsPcmnIn01
    {
        /// <summary>
        /// Method  :   un ou plusieurs comptes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des comptes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 01 - DC-IN02 - COM03</remarks>
        /// <example></example>
        public static List<Response> Execute(List<PcmnIn01> dDataIn01, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn01)
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
