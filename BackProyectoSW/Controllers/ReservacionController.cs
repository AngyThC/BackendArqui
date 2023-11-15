using BackProyectoSW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackProyectoSW.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class ReservacionController : ApiController
    {
        //para las url al momento de crearlas la api quita el sufijo Controller y utiliza lo restante como nombre de url
        //en este caso el nombre del controller es ReservacionController y se le pondra Reservacion
        //GET: api/Reservacion
        public IEnumerable<Reservation> Get()
        {
            ReservacionesManager managerReservacion = new ReservacionesManager();
            //llamar metodo del modelo
            return managerReservacion.GetReservacion();
        }

        public bool Post([FromBody] Reservation reservation)
        {
            ReservacionesManager reservationcustomer = new ReservacionesManager();
            // llamar método del modelo
            bool res = reservationcustomer.AddReservacion(reservation);

            return res;
        }


        // PUT: api/Customer/5
        public bool Put(int id, [FromBody] Reservation reservation)
        {
            ReservacionesManager reservationcustomer = new ReservacionesManager();
            //llamar metodo del modelo
            bool res = reservationcustomer.UpdateReservation(id, reservation);

            return res;
        }
    }
}