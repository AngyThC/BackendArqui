using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class TypeMenu
    {
        //variables de type menu
        public int Id_TypeMenu { get; set; }
        public string Type_Menus { get; set; }
        public string Status { get; set; }

        public TypeMenu() { }

        public TypeMenu(int id, string type_Menu, string status)
        {
            Id_TypeMenu = id;
            Type_Menus = type_Menu;
            Status = status;
        }

        public TypeMenu(string type_Menu, string status)
        {
            Type_Menus = type_Menu;
              Status = status;
        }
        public TypeMenu(string status)
        {
            Status = status;
        }
    }
}