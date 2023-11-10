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
    public class CustomerController : ApiController
    {
        //GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            CustomerManager managerCustomer = new CustomerManager();    
            //llamar metodo del modelo
            return managerCustomer.GetCustomers();
        }

        //No se usa - GET: API/Role
        /* public string Get(int id)
         {
             return "value";
         }*/

        // POST: api/Customer
        public bool Post([FromBody] Customer customer)
        {
            CustomerManager managercustomer = new CustomerManager();
            // llamar método del modelo
            bool res = managercustomer.AddCustomers(customer);

            return res;
        }


        // PUT: api/Customer/5
        public bool Put(int id, [FromBody] Customer customer)
        {
           CustomerManager managercustomer = new CustomerManager();
            //llamar metodo del modelo
            bool res = managercustomer.UpdateCustomers(id, customer);

            return res;
        }

        // DELETE: api/Customer/5
        public bool Delete(int id)
        {
          CustomerManager customerManager= new CustomerManager();
            //llamar metodo del modelo
            bool res = customerManager.DeleteCustomers(id);

            return res;
        }

    }
}