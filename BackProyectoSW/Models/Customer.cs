using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Customer
    {
        public int ID_Customer { get; set; }
        public string Name_Customer { get; set; }
        public string Nit_Customer { get; set; }
        public string Phone_Customer { get; set; }
        public string Addres_Customer { get; set; }
        public string Status_Customer { get; set; }

        public Customer() { }

        public Customer (int ID, string name, string nit, string phone, string addres, string status)
        {
            ID_Customer = ID;
            Name_Customer = name;
            Nit_Customer = nit;
            Phone_Customer = phone;
            Addres_Customer = addres;
            Status_Customer = status;
        }

        public Customer(string name, string nit, string phone, string addres, string status)
        {
            Name_Customer = name;
            Nit_Customer = nit;
            Phone_Customer = phone;
            Addres_Customer = addres;
            Status_Customer = status;
        }
        public Customer(string name)
        {
            Name_Customer = name;
        }

    } 
}