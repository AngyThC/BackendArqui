using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Bill
    {
        public int BillID { get; set; }
        public string TypePay { get; set;}

        public string DescriptionOrder { get; set;}

        public DateTime BillDate { get; set; }

        public decimal Total { get; set; }

        public Bill() { }

        public Bill(int id, string typepay, string descriptionorder, DateTime billdate, decimal total)
        {
            BillID = id;
            TypePay = typepay;
            DescriptionOrder = descriptionorder;
            BillDate = billdate;
            Total = total;
        }

        public Bill(string typepay, string descriptionorder, DateTime billdate, decimal total)
        {
            TypePay = typepay;
            DescriptionOrder = descriptionorder;
            BillDate = billdate;
            Total = total;
        }
    }
}