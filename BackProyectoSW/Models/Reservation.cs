using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }
        public int QuantityPersons { get; set; }
        public string CustomerID { get; set; }
        public int ReservationCost { get; set; }
        public string ReservationTime { get; set; }
        public string Status { get; set; }

        public Reservation() { }

        public Reservation(int ID, string descripcion, DateTime reservationdate, int quantityPerson, string Customerid, int reservationcost, string reservationtime, string status)
        {
            ReservationID = ID;
            Description = descripcion;
            ReservationDate = reservationdate;
            QuantityPersons = quantityPerson;
            CustomerID = Customerid;
            ReservationCost = reservationcost;
            ReservationTime = reservationtime;
            Status = status;
        }

        public Reservation(string descripcion, DateTime reservationdate, int quantityPerson, string Customerid, int reservationcost, string reservationtime, string status)
        {
            Description = descripcion;
            ReservationDate = reservationdate;
            QuantityPersons = quantityPerson;
            CustomerID = Customerid;
            ReservationCost = reservationcost;
            ReservationTime = reservationtime;
            Status = status;
        }
    }
}