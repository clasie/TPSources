// ***********************************************************************************
//
//      Solution            :   WebServiceComptaPlus
//      Projet              :   SideClassWsComptaPlus
//
//      Titre               :   Configuration du projet.
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
namespace SideClassWsComptaPlus.Tools
{
    /// <summary>
    /// Class   :   Class Paramètre suivant le fichier Config du projet.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public class SideErpConfiguration
    {
        /// <summary>
        /// Class   :   Configuration des paramètres pour le ERP.
        /// </summary>
        /// <remarks></remarks>
        /// <returns></returns>
        public partial class ClientConfiguration
        {
            #region Connexion.
            /// <summary>
            /// Param   :  Instance du Serveur avec adresse IP pour le GPT
            /// </summary>
            /// <remarks>string * 80</remarks>
            /// <example>10.10.5.45\OurSql</example>
            public  string InstanceServerGtp { get; set; }
            /// <summary>
            /// Param   :   Nom de la base de donnée du GTP
            /// </summary>
            /// <remarks>string * 80</remarks>
            /// <example>DONNEEGTP</example>
            public string NameDbBusiness { get; set; }
            /// <summary>
            /// Param   :   Utilisateur pour la connexion au SERVER SQL
            /// </summary>
            /// <remarks>string * 30</remarks>
            /// <example>sa</example>
            public string UserConnection { get; set; }
            /// <summary>
            /// Param   :   Mot de passe crytper pour la connexion au SERVER SQL
            /// </summary>
            /// <remarks>string * 15 : IL EST IMPERATIF QUE CE PARAMETRE SOIT CRYPTER POUR L'ENREGISTRER</remarks>
            /// <example>shdjhjs=</example>
            public string PassWordConnection { get; set; }
            #endregion

            #region Tables
            /// <summary>
            /// Param   :  Nom de la table LOG (suivi des opérations du Web Service.)
            /// </summary>
            /// <remarks>string * 50</remarks>
            /// <example>LogWebServices</example>
            public string NameTabeLogWs { get; set; }
            /// <summary>
            /// Param   :  Nom de la table Interface Compta Plus (Liste des différents développement.)
            /// </summary>
            /// <remarks>string * 50</remarks>
            /// <example>LogWebServices</example>
            public string NameTabeTrInterfaceWs { get; set; }
            /// <summary>
            /// Param   :  Nom de la table des Web Services pour Compta Plus.
            /// </summary>
            /// <remarks>string * 50</remarks>
            /// <example>LogWebServices</example>
            public string NameTabeTrWebServices { get; set; }
            #endregion
        }
    }
}
