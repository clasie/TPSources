using ERPDynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Models
{
    public class TokenCheckResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsValidKey { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
