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
    public class OrderDetailsController : ApiController
    {
        // GET: OrderDetails
        //GET: api/Drink
        public IEnumerable<OrderDetails> Get()
        {
            OrderDetailsManager detailsManager = new OrderDetailsManager();
            //llamar metodo del modelo
            return detailsManager.GetOrderDetails();
        }

        [Route("api/OrderDetails/GetDrinkName")]
        [HttpGet]
        public IHttpActionResult GetDrinkName()
        {
            OrderDetailsManager orderDetailManager = new OrderDetailsManager();
            List<Drink> namees = orderDetailManager.GetNameDrink();

            if (namees == null || namees.Count == 0)
            {
                return NotFound();
            }

            return Ok(namees);
        }


        [Route("api/Order/GetDishName")]
        [HttpGet]
        public IHttpActionResult GetDishName()
        {
            OrderDetailsManager orderManager = new OrderDetailsManager();
            List<Dish> namees = orderManager.GetNameDish();

            if (namees == null || namees.Count == 0)
            {
                return NotFound();
            }

            return Ok(namees);
        }

        public bool Post([FromBody] OrderDetails details)
        {
            OrderDetailsManager detailsManager = new OrderDetailsManager();
            // llamar método del modelo
            bool res = detailsManager.AddDetails(details);

            return res;
        }


        // PUT: api/Drink/5
        public bool Put(int id, [FromBody] OrderDetails details)
        {
            OrderDetailsManager detailsManager = new OrderDetailsManager();
            //llamar metodo del modelo
            bool res = detailsManager.UpdateDetails(id, details);

            return res;
        }

    }
}