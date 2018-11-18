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


using FrameWorkSide.Enum;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using CommonVariables.Models.D365;

namespace SideClientWebServiceComptaPlus.Data
{
    /// <summary>
    /// Class   :   Lecture des données factures
    /// </summary>
    public class LoadingDataDummy
    {
        /// <summary>
        /// Liste de plusieurs plan de compte pour le PCMN
        /// </summary>
        /// <param name="dNumber">Numéro de départ</param>
        /// <param name="dCount">Nombre de ligne</param>
        /// <param name="dIdTransaction">N° Transaction</param>
        /// <param name="dTypeEncodage">Définit la ligne a encoder 0 = Standard | 1 = une société | 2 = deux société | 3 = Modifier | 4 = Supprimer 99= Auto</param>
        /// <returns></returns>
        public static ObservableCollection<PcmnD365Model> LoadingPcmnList(int dNumber, int dCount,  long dIdTransaction, int dTypeEncodage)
        {
            try
            {
                var listReturn = new ObservableCollection<PcmnD365Model>();

                for (var i = dNumber; i < dCount; i++)
                {
                    if (dTypeEncodage == 99)
                    {
                        if(i < 10) listReturn.Add(LoadingPcmn(i, dIdTransaction, 0));
                        if(i > 10 && i < 20) listReturn.Add(LoadingPcmn(i, dIdTransaction, 1));
                        if(i > 20 && i < 30) listReturn.Add(LoadingPcmn(i, dIdTransaction, 3));
                        if(i >30 ) listReturn.Add(LoadingPcmn(i, dIdTransaction, 4));
                    }
                    else
                    {
                        listReturn.Add(LoadingPcmn(dNumber, dIdTransaction, dTypeEncodage));
                    }
                }
                
                return listReturn;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new ObservableCollection<PcmnD365Model>();
            }
        }

        /// <summary>
        /// Creation d'un seul plan de compte pour le PCMN
        /// </summary>
        /// <param name="dNumber">Numéro de départ</param>
        /// <param name="dIdTransaction">N° Transaction</param>
        /// <param name="dTypeEncodage">Définit la ligne a encoder 0 = Standard | 1 = une société | 2 = deux société | 3 = Modifier | 4 = Supprimer</param>
        /// <returns></returns>
        public static PcmnD365Model LoadingPcmn(int dNumber, long dIdTransaction, int dTypeEncodage)
        {
            try
            {
                switch (dTypeEncodage)
                {
                    case 0:
                        return new PcmnD365Model
                        {
                            RecId = dNumber,
                            Compagny = new string[] {"001", "009", "030", "040"},
                            IdTransaction = dIdTransaction,
                            IsSuspended = false,
                            MainAccountId = Convert.ToString(608005 + dNumber),
                            MessageError = null,
                            Name = "Compte n° " + dNumber,
                            QueryStatut = StatusQuery.AddElement
                        };
                    case 1:
                        return new PcmnD365Model
                        {
                            RecId = dNumber,
                            Compagny = new string[] {"001"},
                            IdTransaction = dIdTransaction,
                            IsSuspended = false,
                            MainAccountId = Convert.ToString(608005 + dNumber),
                            MessageError = null,
                            Name = "Compte n° " + dNumber,
                            QueryStatut = StatusQuery.AddElement
                        };
                    case 2:
                        return new PcmnD365Model
                        {
                            RecId = dNumber,
                            Compagny = new string[] {"001","009"},
                            IdTransaction = dIdTransaction,
                            IsSuspended = false,
                            MainAccountId = Convert.ToString(608005 + dNumber),
                            MessageError = null,
                            Name = "Compte n° " + dNumber,
                            QueryStatut = StatusQuery.AddElement
                        };
                    case 3:
                        return new PcmnD365Model
                        {
                            RecId = dNumber,
                            Compagny = new string[] {"001"},
                            IdTransaction = dIdTransaction,
                            IsSuspended = false,
                            MainAccountId = Convert.ToString(608005 + dNumber),
                            MessageError = null,
                            Name = "Compte modifié n° " + dNumber,
                            QueryStatut = StatusQuery.UpdateElement
                        };
                    case 4:
                        return new PcmnD365Model
                        {
                            RecId = dNumber,
                            Compagny = new string[] {"001"},
                            IdTransaction = dIdTransaction,
                            IsSuspended = true,
                            MainAccountId = Convert.ToString(608005 + dNumber),
                            MessageError = null,
                            Name = "Compte supprimer n° " + dNumber,
                            QueryStatut = StatusQuery.DeleteElement
                        };
                    default:
                        return new PcmnD365Model();
                }
            }

            catch (Exception)
            {
                return new PcmnD365Model();
            }
        }
    }

}
