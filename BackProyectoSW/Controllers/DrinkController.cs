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
    public class DrinkController : ApiController
    {
        //GET: api/Drink
        public IEnumerable<Drink> Get()
        {
            DrinkManager drinkManager = new DrinkManager();
            //llamar metodo del modelo
            return drinkManager.GetDrinks();
        }

        //No se usa - GET: API/Role
        /* public string Get(int id)
         {
             return "value";
         }*/

        // POST: api/Drink

        [Route("api/Drink/GetTypesOfMenu")]
        [HttpGet]
        public IHttpActionResult GetTypesOfMenu()
        {
            DrinkManager drinkManager = new DrinkManager();
            List<TypeMenu> typesOfMenu = drinkManager.GetTypeMenu();

            if (typesOfMenu == null || typesOfMenu.Count == 0)
            {
                return NotFound();
            }

            return Ok(typesOfMenu);
        }

        public bool Post([FromBody] Drink drinks)
        {
            DrinkManager drinkManager = new DrinkManager();
            // llamar método del modelo
            bool res = drinkManager.AddDrink(drinks);

            return res;
        }


        // PUT: api/Drink/5
        public bool Put(int id, [FromBody] Drink drinks)
        {
            DrinkManager drinkManager = new DrinkManager();
            //llamar metodo del modelo
            bool res = drinkManager.UpdateDrink(id, drinks);

            return res;
        }

        // DELETE: api/Drink/5
        public bool Delete(int id)
        {
            DrinkManager drinkManager = new DrinkManager();
            //llamar metodo del modelo
            bool res = drinkManager.DeleteDrink(id);

            return res;
        }

    }
}