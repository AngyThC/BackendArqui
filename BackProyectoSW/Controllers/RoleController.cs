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
    public class RoleController : ApiController
    {
        // GET: api/Role
        public IEnumerable<Role> Get()
        {
            RoleManager managerRole = new RoleManager();
            //llamar metodo del modelo
            return managerRole.GetRoles();
        }

        // GET: api/Role/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        public bool Post([FromBody] Role role)
        {
            RoleManager managerRole = new RoleManager();
            //llamar metodo del modelo
            bool res = managerRole.AddRole(role);

            return res;
        }

        // PUT: api/Role/5
        public bool Put(int id, [FromBody] Role role)
        {
            RoleManager managerRole = new RoleManager();
            //llamar metodo del modelo
            bool res = managerRole.UpdateRole(id, role);

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