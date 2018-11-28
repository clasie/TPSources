using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSComptaPlus.Models;

namespace WSComptaPlus.BasicAuth
{
    public class Auth
    {
        private static readonly Lazy<Auth> lazy =
            new Lazy<Auth>(() => new Auth());

        public static Auth Instance { get { return lazy.Value; } }

        private Auth()
        {
        }
        public User UserExists(User user)
        {
           return UserExistsInConfig(user);
        }
        private User  UserExistsInConfig(User user)
        {
            return ApplicationData.Instance.UserExists(user);

        }
    }
}