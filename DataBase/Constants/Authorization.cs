using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Employee,
            User
        }
        public const string default_username = "admin";
        public const string default_email = "no-reply.techno_world@abv.bg";
        public const string default_password = "admin";
        public const Roles default_role = Roles.Administrator;
    }
}
