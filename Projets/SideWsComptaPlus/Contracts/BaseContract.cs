using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideWsComptaPlus.Contracts
{
    /// <summary>
    /// Class Contract  : les bases à joindre aux autres contrats
    /// </summary>
    public class BaseContract
    {
        /// <summary>
        /// Property    :   Obtient/Définit la procédure de travail pour le Query.
        /// </summary>
        /// <remarks> Enumérateur : 0= ADD | 1= UPDATE | 2= DELETE</remarks>
        /// <example></example>
        public Enum.StatusQuery StatusQuery { get; set; }
        /// <summary>
        /// Property    :   Obtient/Définit le numéro de l'opération venant du Web Service de D365
        /// </summary>
        /// <remarks></remarks>
        /// <example></example>
        public Guid DynamicsOprNumber { get; set; }
    }
}
