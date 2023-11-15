using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Users
    {
        public int UserID { get; set; }

        public string RoleName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Users() { }

        public Users(int id,  string rolename, string username)
        {
            UserID = id;
            RoleName = rolename;
            UserName = username;
        }

        public Users( string password, string username)
        {
            Password = password;
            UserName = username;
        }

        public Users(string rolename, string username, string password)
        {
            RoleName = rolename;
            UserName = username;
            Password = password;
        }

        public Users(string rolename)
        {
            RoleName = rolename;
        }
    }
}