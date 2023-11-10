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

    public class OrderController : ApiController
    {

        // GET: OrderDetails
        //GET: api/Drink
        public IEnumerable<Order> Get()
        {
            OrderManager OrderManager = new OrderManager();
            //llamar metodo del modelo
            return OrderManager.GetOrder();
        }

        [Route("api/Order/GetCustomName")]
        [HttpGet]
        public IHttpActionResult GetCustomName()
        {
            OrderManager orderManager = new OrderManager();
            List<Customer> namees = orderManager.GetNameCustom();

            if (namees == null || namees.Count == 0)
            {
                return NotFound();
            }

            return Ok(namees);
        }



        public bool Post([FromBody] Order orders)
        {
            OrderManager OrderManager = new OrderManager();
            // llamar método del modelo
            bool res = OrderManager.AddOrder(orders);

            return res;
        }

        public bool Put(int id, [FromBody] Order orders)
        {
            OrderManager orderManager = new OrderManager();
            //llamar metodo del modelo
            bool res = orderManager.UpdateOrder(id, orders);

            return res;
        }

    }
}