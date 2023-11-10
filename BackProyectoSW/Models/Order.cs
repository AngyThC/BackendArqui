using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Order
    {

        public int OrderID { get; set; }
        public string TypeOrder { get; set; }
        public string Name_Customer { get; set; }
        public string DescriptionOrder { get; set; }
        public string Status { get; set; }

        public Order() { }

        public Order(int id, string type, string customerid, string description, string estado)
        { 
        
            OrderID = id;
            TypeOrder = type;
            Name_Customer = customerid;
            DescriptionOrder = description;
            Status = estado;    
        }

        public Order(string type, string customerid, string description, string estado)
        {

            TypeOrder = type;
            Name_Customer = customerid;
            DescriptionOrder = description;
            Status = estado;

        }

        public Order(string descriptionorder)
        {
            DescriptionOrder = descriptionorder;
        }
    }
}