using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public string DishID { get; set; }
        public decimal QuantityDish { get; set; }
        public string DrinkID { get; set; }
        public decimal QuantityDrink { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderID { get; set; }

        public OrderDetails() { }

        public OrderDetails(int id, string dishid, decimal quantitydish, string drinkid, decimal quatityid, decimal totalamount, int orderid)
        {
            OrderDetailsID = id;
            DishID = dishid;
            QuantityDish = quantitydish;
            DrinkID = drinkid;
            QuantityDrink = quatityid;
            TotalAmount = totalamount;
            OrderID = orderid;
        }

        public OrderDetails(string dishid, decimal quantitydish, string drinkid, decimal quatityid, decimal totalamount, int orderid)
        {
            DishID = dishid;
            QuantityDish = quantitydish;
            DrinkID = drinkid;
            QuantityDrink = quatityid;
            TotalAmount = totalamount;
            OrderID = orderid;
        }
    }
}