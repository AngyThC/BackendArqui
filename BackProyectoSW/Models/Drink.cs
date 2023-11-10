using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BackProyectoSW.Models
{
    public class Drink
    {
        public int DrinkID { get; set; }
        public string DrinkName { get; set; }
        public string DrinkDescription { get; set; }
        public decimal DrinkPrice { get; set;}
        public string TypeMenuName { get; set; }
        public string Status { get; set; }

        public Drink() { }

        public Drink(int id, string drinkName, string drinkDescripcion, decimal drinkPrice, string typeMenuname, string status)
        {
            DrinkID = id;
            DrinkName = drinkName;
            DrinkDescription = drinkDescripcion;
            DrinkPrice = drinkPrice;
            TypeMenuName = typeMenuname;
            Status = status;
        }

        public Drink(string drinkName, string drinkDescripcion, decimal drinkPrice, string typeMenuname, string status)
        {
            DrinkName = drinkName;
            DrinkDescription = drinkDescripcion;
            DrinkPrice = drinkPrice;
            TypeMenuName = typeMenuname;
            Status = status;
        }

        public Drink(string name)
        {
            DrinkName = name;
        }
    }
}