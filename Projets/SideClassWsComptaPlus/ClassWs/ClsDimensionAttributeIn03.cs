// ***********************************************************************************
//
//      Solution            :   WebServiceComptaPlus
//      Projet              :   SideClassWsComptaPlus
//
//      Titre               :   Class des valeurs de dimensions analytique - Interface 03
//      Description         :   -
//
//      Démarrage           :   26-09-2018
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
using SideWsComptaPlus.Contracts;
using System;
using System.Collections.Generic;
using SideWsComptaPlus.ModelBusiness;
using SideFrameWork.Enum;

namespace SideClassWsComptaPlus.ClassWs
{
    /// <summary>
    /// Class    :   Valeurs de dimensions analytiques.
    /// </summary>
    /// <returns></returns>
    /// <remarks>Interface 03 - DC-IN03 - COM06</remarks>
    public class ClsDimensionAttributeIn03
    {
        #region Old

        ///// <summary>
        ///// Method  :   Gestion Business du setup des dimensions analytique.
        ///// </summary>
        ///// <param name="dDataDimensionAttributeSetup">Obtient ou Définit la liste des dimensions des comptes analytiques</param>
        ///// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        ///// <remarks>Interface 03 - DC-IN03 - COM06</remarks>
        ///// <example></example>
        //public static List<Response> ExecuteDimensionAttributeSetup(List<DimensionAttributeSetupIn03> dDataDimensionAttributeSetup)
        //{
        //    // Simulation du message de retour.
        //    var listResponse = new List<Response>();
        //    var captureOpNumberErp = Guid.Empty;

        //    var compt = 0;
        //    foreach (var elementDimensionAttributeSetup in dDataDimensionAttributeSetup)
        //    {
        //        compt++;
        //        Response messageReturn;
        //        if (compt <= 1)
        //        {
        //            #region D365

        //            messageReturn = new Response
        //            {
        //                Code = "0",
        //                Message = "Dimension analytique " + elementDimensionAttributeSetup.DimensionName +
        //                          " a été correctement enregistré.",
        //                ERPOprNumber = captureOpNumberErp,
        //                DynamicsOprNumber = elementDimensionAttributeSetup.DynamicsOprNumber
        //            };
        //            listResponse.Add(messageReturn);
        //            #endregion
        //            #region Log du Web Service
        //            logTransaction.ReceiveLog(1, 10, "WS-DEV", elementDimensionAttributeSetup.DynamicsOprNumber, captureOpNumberErp,
        //            //    (StatusQuery)elementDimensionAttributeSetup.StatusQuery ,
        //            //    elementDimensionAttributeSetup.DimensionName, messageReturn.Code, messageReturn.Message, "Nothing", "MULTI",
        //            //    false , StatutTransaction.EtatClosed);
        //            #endregion
        //        }
        //        else
        //        {
        //            #region D365
        //            // une seule société.
        //            messageReturn = new Response
        //            {
        //                Code = "10010005",
        //                Message = "Cette dimension analytique " + elementDimensionAttributeSetup.DimensionName +
        //                          " n'a pas pu être transmis à la société " +
        //                          elementDimensionAttributeSetup.Company[0].ToString(),
        //                ERPOprNumber = captureOpNumberErp,
        //                DynamicsOprNumber = elementDimensionAttributeSetup.DynamicsOprNumber
        //            };
        //            listResponse.Add(messageReturn);
        //            #endregion
        //            #region Log du Web Service
        //            logTransaction.ReceiveLog(1, 10, "WS-DEV", elementDimensionAttributeSetup.DynamicsOprNumber, captureOpNumberErp,
        //            //    (StatusQuery)elementDimensionAttributeSetup.StatusQuery ,
        //            //    elementDimensionAttributeSetup.DimensionName, messageReturn.Code, messageReturn.Message, "Nothing", "MULTI",
        //            //    false , StatutTransaction.EtatError);
        //            #endregion
        //        }

        //    }
        //    return listResponse;
        //}

        ///// <summary>
        ///// Method  :   Gestion Business  des dimensions analytique.
        ///// </summary>
        ///// <param name="dDataDimensionAttributeValue">Obtient ou Définit la liste des dimensions des comptes analytiques</param>
        ///// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        ///// <remarks>Interface 03 - DC-IN03 - COM06</remarks>
        ///// <example></example>
        //public static List<Response> ExecuteDimensionAttributeValue(List<DimensionAttributeValueIn03> dDataDimensionAttributeValue)
        //{
        //    // Simulation du message de retour.
        //    var listResponse = new List<Response>();
        //    var captureOpNumberErp = Guid.Empty;
        //    var compt = 0;

        //    foreach (var elementDimensionAttributeValue in dDataDimensionAttributeValue)
        //    {
        //        compt++;
        //        Response messageReturn;
        //        if (compt <= 1)
        //        {
        //            #region D365
        //            messageReturn = new Response
        //            {
        //                Code = "0",
        //                Message = "Dimension analytique " + elementDimensionAttributeValue.DimensionName +
        //                          " a été correctement enregistré.",
        //                ERPOprNumber = captureOpNumberErp,
        //                DynamicsOprNumber = elementDimensionAttributeValue.DynamicsOprNumber
        //            };
        //            listResponse.Add(messageReturn);
        //            #endregion
        //            #region Log du Web Service
        //            logTransaction.ReceiveLog(1, 11, "WS-DEV", elementDimensionAttributeValue.DynamicsOprNumber, captureOpNumberErp,
        //            //  (StatusQuery) elementDimensionAttributeValue.StatusQuery,
        //            //    elementDimensionAttributeValue.DimensionName, messageReturn.Code, messageReturn.Message, "Nothing", "MULTI",
        //            //    false , StatutTransaction.EtatClosed);
        //            #endregion
        //        }
        //        else
        //        {
        //            #region D365
        //            // une seule société.
        //            messageReturn = new Response
        //            {
        //                Code = "10010005",
        //                Message = "Cette dimension analytique " + elementDimensionAttributeValue.DimensionName +
        //                          " n'a pas pu être transmis à la société " +
        //                          elementDimensionAttributeValue.Company[0],
        //                ERPOprNumber = captureOpNumberErp,
        //                DynamicsOprNumber = elementDimensionAttributeValue.DynamicsOprNumber
        //            };
        //            listResponse.Add(messageReturn);
        //            #endregion
        //            #region Log du Web Service
        //            logTransaction.ReceiveLog(1, 11, "WS-DEV", elementDimensionAttributeValue.DynamicsOprNumber, captureOpNumberErp,
        //            //    (StatusQuery) elementDimensionAttributeValue.StatusQuery,
        //            //    elementDimensionAttributeValue.DimensionName, messageReturn.Code, messageReturn.Message, "Nothing", "MULTI",
        //            //    false , StatutTransaction.EtatError);
        //            #endregion
        //        }

        //    }
        //    return listResponse;
        //}

        #endregion

        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteAxeAnalytique(List<DimensionAttributeSetupIn03> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
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

        /// <summary>
        /// Method  :   un ou plusieurs groupes de taxes envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteCompteAnalytique(List<DimensionAttributeValueIn03> dDataIn03, TypeEnvironment dEnvironnement)
        {
            var ListResponse = new List<Response>();
            foreach (var element in dDataIn03)
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
