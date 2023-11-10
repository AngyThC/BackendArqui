using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Role
    {
        //Variables de tabla Role
        public int ID_Role { get; set; }
        public string Name_Role { get; set; }

        public Role() { }

        public Role(int id, string name)
        {
            ID_Role = id;
            Name_Role = name;
        }

        public Role(string name)
        {
            Name_Role = name;
        }
    }
}