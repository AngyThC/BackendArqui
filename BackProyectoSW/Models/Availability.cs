using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackProyectoSW.Models
{
    public class Availability
    {
        public int AvailibityID { get; set; }

        public int AvailibityPersonsMAX { get; set; }

        public int AvailibityPersonsMIN { get; set; }

        public int AvailibityReservationDailyMAX { get; set; }

        public int AvailibityReservationWeeklyMAX { get; set; }

        public int AvailibityReservationMonthlyMAX { get; set; }

        public Availability() { }

        public Availability(int id, int pMAX, int pMIN, int dMAX, int wMAX, int mMAX)
        {
            AvailibityID = id;
            AvailibityPersonsMAX = pMAX;
            AvailibityPersonsMIN = pMIN;
            AvailibityReservationDailyMAX = dMAX;
            AvailibityReservationWeeklyMAX = wMAX;
            AvailibityReservationMonthlyMAX = mMAX;
        }

        public Availability(int pMAX, int pMIN, int dMAX, int wMAX, int mMAX)
        {
            AvailibityPersonsMAX = pMAX;
            AvailibityPersonsMIN = pMIN;
            AvailibityReservationDailyMAX = dMAX;
            AvailibityReservationWeeklyMAX = wMAX;
            AvailibityReservationMonthlyMAX = mMAX;
        }
    }
}