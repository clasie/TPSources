using System;

namespace SideWsComptaPlus.ModelBusiness
{
    /// <summary>
    /// Class Business  :   Retour des informations du résultat venant du Service.
    /// </summary>
    /// <remarks>Est une liste de retour dans le service</remarks>
    public class Response
    {
        /// <summary>
        /// Définit/Obtient le numéro d'opération du service ERP.
        /// </summary>
        /// <remarks>Type Guid</remarks>
        public Guid ErpOprNumber { get; set; }
        /// <summary>
        /// Définit/Obtient le numéro d'opération du service Dynamics.
        /// </summary>
        /// <remarks>Type Guid</remarks>
        public Guid DynamicsOprNumber { get; set; }
        /// <summary>
        /// Définit/Obtient le message de retour du résultat d'opération du service.
        /// </summary>
        /// <remarks>Type string (à discuter de la longueur)</remarks>
        public string Message { get; set; }
        /// <summary>
        /// Définit/Obtient le code de retour du résultat d'opération du service.
        /// </summary>
        /// <remarks>Type string  =>  0=Aucune erreur. </remarks>
        public string Code { get; set; }
    }
}
