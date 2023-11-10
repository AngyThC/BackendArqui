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
    public class AvailabilityController : ApiController
    {
        //GET: api/Availability
        public IEnumerable<Availability> Get()
        {
            AvailabilityManager managerAvailability = new AvailabilityManager();
            //llamar metodo del modelo
            return managerAvailability.GetAvailability();
        }

        //No se usa - GET: API/Role
        /* public string Get(int id)
         {
             return "value";
         }*/

        // POST: api/Availability
        public bool Post([FromBody] Availability availability)
        {
            AvailabilityManager managerAvailability = new AvailabilityManager();
            // llamar método del modelo
            bool res = managerAvailability.AddAvailability(availability);

            return res;
        }


        // PUT: api/Availability/5
        public bool Put(int id, [FromBody] Availability availability)
        {
            AvailabilityManager managerAvailability = new AvailabilityManager();
            //llamar metodo del modelo
            bool res = managerAvailability.UpdateAvailability(id, availability);

            return res;
        }

        // DELETE: api/Role/5
        public bool Delete(int id)
        {
            AvailabilityManager managerAvailability = new AvailabilityManager();
            //llamar metodo del modelo
            bool res = managerAvailability.DeleteAvailability(id);

            return res;
        }
    }
}