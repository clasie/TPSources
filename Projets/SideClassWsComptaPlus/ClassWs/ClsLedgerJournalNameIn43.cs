using System;
using System.Collections.Generic;
using SideWsComptaPlus.Contracts;
using SideWsComptaPlus.ModelBusiness;
using SideFrameWork.Enum;

namespace SideClassWsComptaPlus.ClassWs
{
    public class ClsLedgerJournalNameIn43
    {
        #region Old

        ///// <summary>
        ///// Method  :   Gestion Business  les journaux.
        ///// </summary>
        ///// <param name="dDataLedgerJournalNameIn43">Obtient ou Définit la liste de données des journaux</param>
        ///// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        ///// <remarks></remarks>
        ///// <example></example>
        //public static List<Response> ExecuteLedgerJournalName(List<LedgerJournalNameIn43> dDataLedgerJournalNameIn43)
        //{
        //    // Simulation du message de retour.
        //    var listResponse = new List<Response>();
        //    var captureOpNumberErp = Guid.Empty;

        //    var compt = 0;
        //    foreach (var elementLedgerJournalName in dDataLedgerJournalNameIn43)
        //    {
        //        compt++;
        //        Response messageReturn;
        //        if (compt <= 1)
        //        {
        //            #region D365
        //            messageReturn = new Response
        //            {
        //                Code = "0",
        //                Message = "Journal " + elementLedgerJournalName.JounalName +
        //                          " a été correctement enregistré.",
        //                ERPOprNumber = captureOpNumberErp,
        //                DynamicsOprNumber = elementLedgerJournalName.DynamicsOprNumber
        //            };
        //            listResponse.Add(messageReturn);
        //            #endregion

        //            #region Log du Web Service
        //            logTransaction.ReceiveLog(1, 13, "WS-DEV", elementLedgerJournalName.DynamicsOprNumber, captureOpNumberErp, (StatusQuery)elementLedgerJournalName.StatusQuery,
        //            //    elementLedgerJournalName.JounalName, messageReturn.Code, messageReturn.Message, "Nothing", "MULTI", false, StatutTransaction.EtatClosed);
        //            #endregion
        //        }
        //        else
        //        {
        //            #region D365
        //            // une seule société.
        //            messageReturn = new Response
        //            {
        //                Code = "10010005",
        //                Message = "Ce journal " + elementLedgerJournalName.JounalName +
        //                          " n'a pas pu être transmis à la société " +
        //                          elementLedgerJournalName.Company[0],
        //                ERPOprNumber = captureOpNumberErp,
        //                DynamicsOprNumber = elementLedgerJournalName.DynamicsOprNumber
        //            };
        //            listResponse.Add(messageReturn);
        //            #endregion
        //            #region Log du Web Service
        //            logTransaction.ReceiveLog(1, 13, "WS-DEV", elementLedgerJournalName.DynamicsOprNumber, captureOpNumberErp, (StatusQuery)elementLedgerJournalName.StatusQuery,
        //            //    elementLedgerJournalName.JounalName, messageReturn.Code, messageReturn.Message, "Nothing", "MULTI", false, StatutTransaction.EtatClosed);
        //            #endregion
        //        }
        //    }
        //    return listResponse;
        //}

        #endregion

        /// <summary>
        /// Method  :   un ou plusieurs Journaux envoyés par D365.
        /// </summary>
        /// <param name="dDataIn01">Obtient ou Définit la liste des groupes de taxes.</param>
        /// <returns>Le résultat en rapport des instructions de travail de liaison avec le Business </returns>
        /// <remarks>Interface 36 - DC-IN04 - COM09</remarks>
        /// <example></example>
        public static List<Response> ExecuteJournaux(List<LedgerJournalNameIn43> dDataIn03, TypeEnvironment dEnvironnement)
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
