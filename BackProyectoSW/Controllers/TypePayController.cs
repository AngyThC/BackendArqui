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
    public class TypePayController : ApiController
    {
        // GET: api/TypePay
        public IEnumerable<TypePay> Get()
        {
            TypePayManager managerTypePay = new TypePayManager();
            //llamar metodo del modelo
            return managerTypePay.GetTypePays();
        }

        //// GET: api/Role/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/TypePay
        public bool Post([FromBody] TypePay typePay)
        {
            TypePayManager managerTypePay = new TypePayManager();
            //llamar metodo del modelo
            bool res = managerTypePay.AddTypePays(typePay);

            return res;
        }

        // PUT: api/TypePay/1
        public bool Put(int id, [FromBody] TypePay typePay)
        {
            TypePayManager managerTypePay = new TypePayManager();
            //llamar metodo del modelo
            bool res = managerTypePay.UpdateTypePays(id, typePay);

            return res;
        }

        // DELETE: api/Role/5
        public bool Delete(int id)
        {
            RoleManager managerRole = new RoleManager();
            //llamar metodo del modelo
            bool res = managerRole.DeleteRole(id);

            return res;
        }
    }
}