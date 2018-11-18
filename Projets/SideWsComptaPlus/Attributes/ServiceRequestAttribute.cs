using System;

namespace SideWsComptaPlus.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// Attribute    : URL de base du Web Service.
    /// </summary>
    public class ServiceRequestAttribute:Attribute
    {
        /// <summary>
        /// URL pour le service
        /// </summary>
        public string Url { get; set; }
    }
}
