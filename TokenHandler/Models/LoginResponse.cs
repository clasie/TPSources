using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TokenHandler.Models
{
    public class LoginResponse
    {
        public LoginResponse()
        {

            this.Token = "";
            //this.HttpResponseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        //public HttpResponseMessage HttpResponseMsg { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string ResponseMsg { get; set; }

    }
}
