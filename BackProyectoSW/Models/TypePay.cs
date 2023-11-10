using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class TypePay
    {
        //variables de tabla TypePay
        public int ID_typepay { get; set; }
        public string Name_typepay { get; set; }
        public string Status { get; set; }

        public TypePay() { }

        public TypePay(int id, string name, string status)
        {
            ID_typepay = id;
            Name_typepay = name;
            Status = status;
        }

        public TypePay(string name, string status)
        {
            Name_typepay = name;
            Status = status;
        }

        public TypePay(string name)
        {
            Name_typepay = name;
        }
    }
}