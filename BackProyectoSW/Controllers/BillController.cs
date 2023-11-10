using BackProyectoSW.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackProyectoSW.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class BillController : ApiController
    {
        public IEnumerable<Bill> Get()
        {
            BillManager billManager = new BillManager();
            //llamar metodo del modelo
            return billManager.GetBills();
        }

        public bool Post([FromBody] Bill bill)
        {
            BillManager billManager = new BillManager();
            // llamar método del modelo
            bool res = billManager.AddBill(bill);

            return res;
        }

        [Route("api/Bill/GetTypePay")]
        [HttpGet]
        public IHttpActionResult GetTypePay()
        {
            BillManager billManager = new BillManager();
            List<TypePay> namees = billManager.GetNametypepay();

            if (namees == null || namees.Count == 0)
            {
                return NotFound();
            } 

            return Ok(namees);
        }

        [Route("api/Bill/GetDescriptionOrder")]
        [HttpGet]
        public IHttpActionResult GetDescriptionOrder()
        {
            BillManager billManager = new BillManager();
            List<Order> namees = billManager.GetDescriptionOrder();

            if (namees == null || namees.Count == 0)
            {
                return NotFound();
            }

            return Ok(namees);
        }


        // PUT: api/Drink/5
        public bool Put(int id, [FromBody] Bill details)
        {
            BillManager billManager = new BillManager();
            //llamar metodo del modelo
            bool res = billManager.UpdateBill(id, details);

            return res;
        }
    }
}