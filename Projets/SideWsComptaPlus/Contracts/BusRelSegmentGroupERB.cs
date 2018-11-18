using SideWsComptaPlus.Attributes;
using SideWsComptaPlus.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideWsComptaPlus.Contracts
{
    [ServiceRequest(Url = "api/services/NVL_Dynamics_ERP/NVL_ERPTableReferenceService/syncBusRelSegmentGroup")]
    public class BusRelSegmentGroupERB : BaseContractERP
    {
        public string SegmentId { get; set; }
        public string Description { get; set; }
    }
}
