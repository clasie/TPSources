using System;
using System.Runtime.Serialization;

namespace WSComptaPlus.Models
{
    [DataContract]
    public class WsInfoModel
    {
        #region Membres        
        #endregion

        #region Propriétés
        /// <summary>
        /// Identifiant interne du Web Services
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }
        /// <summary>
        /// Nom du Web Services
        /// </summary>
        [DataMember]
        public string NomWs { get; set; }
        /// <summary>
        /// Description sur le Web Services 
        /// </summary>
        [DataMember]
        public string DescriptionWs { get; set; }
        /// <summary>
        /// Description sur le Web Services 
        /// </summary>
        [DataMember]
        public string EtatWs { get; set; }
        /// <summary>
        /// CopyRight du Web Services 
        /// </summary>
        [DataMember]
        public string CopyRightWs { get; set; }
        #endregion

    }
}