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
    public class DishController : ApiController
    {
        //GET: api/Dish
        public IEnumerable<Dish> Get()
        {
            DishManager dishManager = new DishManager();
            //llamar metodo del modelo
            return dishManager.DishGets();
        }

        //No se usa - GET: API/Role
        /* public string Get(int id)
         {
             return "value";
         }*/

        [Route("api/Dish/GetTypesOfMenu")]
        [HttpGet]
        public IHttpActionResult GetTypesOfMenu()
        {
            DishManager dishManager = new DishManager();
            List<TypeMenu> typesOfMenu = dishManager.GetTypeMenu();

            if (typesOfMenu == null || typesOfMenu.Count == 0)
            {
                return NotFound();
            }

            return Ok(typesOfMenu);
        }

        // POST: api/Dish
        public bool Post([FromBody] Dish dishes)
        {
            DishManager dishManager = new DishManager();
            // llamar método del modelo
            bool res = dishManager.AddDishes(dishes);

            return res;
        }

        // PUT: api/Dish/5
        public bool Put(int id, [FromBody] Dish dishes)
        {
            DishManager dishManager = new DishManager();
            //llamar metodo del modelo
            bool res = dishManager.UpdateDish(id, dishes);

            return res;
        }

        // DELETE: api/Dish/5
        public bool Delete(int id)
        {
            DishManager dishManager = new DishManager();
            //llamar metodo del modelo
            bool res = dishManager.DeleteDish(id);

            return res;
        }
    }
}