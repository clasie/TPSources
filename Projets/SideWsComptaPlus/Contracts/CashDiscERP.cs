using SideWsComptaPlus.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideWsComptaPlus.Contracts
{
    [ServiceRequest(Url = "api/services/NVL_Dynamics_ERP/NVL_ERPTableReferenceService/syncCashDisc")]
    public class CashDiscERP : BaseContractERP
    {
        public string CashDiscCode { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string MainAccountCustomer { get; set; }
        public string MainAccountVendor { get; set; }
        public int NumOfDays { get; set; }
        public decimal Percent { get; set; }
    }
}
