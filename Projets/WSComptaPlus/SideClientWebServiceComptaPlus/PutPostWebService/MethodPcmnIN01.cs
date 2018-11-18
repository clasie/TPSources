//-----------------------------------------------------------------------------------
//
//  Application     :   Gestion des méthodes du Web Services (partie client)
//
//  Langage         :   C# 7.0 sous Visual Studio 2017 Community
//
//  FrameWork       :   4.6.1.1.
//
//  Projet          :   DLL FrameWorkSide (informations communes)
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

using CommonVariables.Models.D365;
using FrameWorkSide.DataBase.WebServices;
using FrameWorkSide.Enum;
using FrameWorkSide.Models.WebServices;
using System;
using System.Collections.ObjectModel;

namespace SideClientWebServiceComptaPlus.PutPostWebService
{
    /// <summary>
    /// Envoyer dans le ERP les informations pour un/plusieurs compte(s) du PCMN
    /// </summary>
    public class MethodPcmnIn01
    {
        /// <summary>
        ///  Code Pre-Programmé :   Envoyer dans le ERP les informations pour un compte du PCMN
        /// </summary>
        /// <param name="obj">Définit les données d'un compte PCMN</param>
        /// <param name="dModeCnx">Définit le mode de travail (Production ou Développement)</param>
        /// <param name="urlBase">Définit Url de base du Web Service</param>
        /// <returns></returns>
        public static Response ElementPcmn365(PcmnD365Model obj, ModeCnxEnvironmentTp dModeCnx, string urlBase)
        {
            // ---- Etape ----
            //
            // 1. Envoyer le mode de travail au service (Production ou Développement).
            // 2. Execute la demande au service.
            try
            {
                // 1. Paramètres.
                #region A continuer et terminer
                
                #endregion
                
                // 2. Execute avec le Service.
                var profile = new WebServiceContext<PcmnD365Model>(urlBase);
                var vretour = (Response)profile.SendRequest("pcmn", "element", HttpMethod.POST, obj);
                return vretour;

            }
            // Erreur.
            catch (Exception e)
            {
               // MessageBox.Show(e.Message);
                return new Response
                {
                    Code = "99999999",
                    Message = e.Message
                };
            }
        }

        /// <summary>
        /// Code Pre-Programmé : Envoyer dans le ERP une liste d'informations pour un compte du PCMN
        /// </summary>
        /// <param name="obj">Définit les données d'un compte PCMN</param>
        /// <param name="dModeCnx">Définit le mode de travail (Production ou Développement)</param>
        /// <param name="urlBase"></param>
        /// <returns></returns>
        public static Response ListPcmn365(ObservableCollection<PcmnD365Model> obj, 
            ModeCnxEnvironmentTp dModeCnx, string urlBase)
        {
            // ---- Etape ----
            //
            // 1. Envoyer le mode de travail au service (Production ou Développement).
            // 2. Execute la demande au service.
            try
            {
                // 1. Paramètres.
                #region A continuer et terminer
                #endregion
                
                // 2. Execute avec le Service.
                var profile = new WebServiceContext<ObservableCollection<PcmnD365Model>>(urlBase);
                var vretour = (Response)profile.SendRequest("pcmn", "list", HttpMethod.POST, obj);
                return vretour;
            }
            // Erreur.
            catch (Exception e)
            {
               // MessageBox.Show(e.Message);
                return new Response
                {
                    Code = "99999999",
                    Message = e.Message
                };
            }
        }
    }
}
