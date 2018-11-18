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
using System.Windows.Media;

namespace SideClientWebServiceComptaPlus.Models
{
    /// <summary>
    /// Class Business  :   Permet de gérer la liste des retours.
    /// </summary>
    public class ListeSideTypeA
    {
        /// <summary>
        /// Symbole du résultat (En erreur, Réussi, Info, rien)
        /// </summary>
        public string EtatLine { get; set; }
        /// <summary>
        /// Les messages de retours
        /// </summary>
        public string LabelList { get; set; }
    }
}
