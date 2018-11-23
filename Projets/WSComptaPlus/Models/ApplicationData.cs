using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSComptaPlus.Models
{
    public class ApplicationData
    {
        private static readonly Lazy<ApplicationData> lazy =
            new Lazy<ApplicationData>(() => new ApplicationData());

        public static ApplicationData Instance { get { return lazy.Value; } }

        private ApplicationData()
        {}

        public List<User> listUsers = new List<User>() { };
    }
}