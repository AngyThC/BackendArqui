using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Dish
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public decimal DishPrice { get; set; }
        public string TypeMenuName { get; set; }
        public string Status { get; set; }


        public Dish() { }

        public Dish(int id, string dishName, string dishDescription, decimal dishPrice, string typeMenuname, string status)
        {
            DishID = id;
            DishName = dishName;
            DishDescription = dishDescription;
            DishPrice = dishPrice;
            TypeMenuName = typeMenuname;
            Status = status;

        }

        public Dish(string dishName, string dishDescription, decimal dishPrice, string typeMenuname, string status)
        {
            DishName = dishName;
            DishDescription = dishDescription;
            DishPrice = dishPrice;
            TypeMenuName = typeMenuname;
            Status = status;    
        }

        public Dish(string name)
        {
            DishName = name;
        }
    } 
}