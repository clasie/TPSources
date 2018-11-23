using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Utils
{
    public class TokenExceptionFormat
    {
        public static List<ERPDynamics.Response> GetResponseForRefusedToken(string message) {
            return new List<ERPDynamics.Response>(){
                new ERPDynamics.Response() {
                Code = "TODO",
                DynamicsOprNumber = Guid.Empty,
                ERPOprNumber = Guid.Empty,
                Message = message
            }
            };
        }
        public static List<ERPDynamics.Response> GetResponseForDebug(string message)
        {
            return new List<ERPDynamics.Response>(){
                new ERPDynamics.Response() {
                Message = message
            }
            };
        }
    }
}
