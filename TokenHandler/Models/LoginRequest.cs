using ERPDynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Models
{
    //[SideWsComptaPlus.Attributes.ServiceRequest (Url = "login/ws")]
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
