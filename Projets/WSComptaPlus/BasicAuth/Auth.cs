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
        //call db for a user creds
        public User UserExists(User user)
        {
           return UserExistsInDb(user);
        }
        private User  UserExistsInDb(User user)
        {
            //TODO call DB/config, ok  on est dans le context web -> charger la config en mémoire!
            //...
            user.Exists = false;
            return user;
        }
    }
}