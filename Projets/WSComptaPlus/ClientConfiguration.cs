namespace WSComptaPlus
{
    //TODO: A voir lors de la mise en place de la sécurité et configuration.
    
    /// <summary>
    /// Class   :   Configuation du côté client.
    /// </summary>
    public partial class ClientConfiguration
    {
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ErpVersion { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string UriString { get; set; }
        /// <summary>
        /// Param   :   Nom de l'utilisateur pour l'accès au Web Service du ERP.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Param   :   Mot de passe de l'utilisateur pour l'accès
        /// au Web Service du ERP.
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ActiveDirectoryResource { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ActiveDirectoryTenant { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ActiveDirectoryClientAppId { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ActiveDirectoryClientAppSecret { get; set; }

        /// <summary>
        /// Param   :   
        /// </summary>
        public string ErpSalesClientId { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ErpSalesUri { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ErpSalesClientKey { get; set; }
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ActiveDirectoryTenantId { get; set; }
        
        /// <summary>
        /// Param   :   
        /// </summary>
        public string ServiceGroup { get; set; }
    }
}
