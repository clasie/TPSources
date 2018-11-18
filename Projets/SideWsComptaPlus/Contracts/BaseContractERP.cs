using System;

namespace SideWsComptaPlus.Contracts
{
    /// <summary>
    /// Class Contract  : les bases à joindre aux autres contrats
    /// </summary>
    public class BaseContractERP
    {
        public Guid ERPOprNumber { get; set; }
        public StatusQuery StatusQuery { get; set; }
    }
}
