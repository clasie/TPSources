using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSComptaPlus.Models
{
    public class User
    {
        public User() {
            Token = "NoTokenCreated";
            Exists = false;//debug, to remove!
        }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public bool Exists { get; set; }
        public string Token { get; set; }
}
}