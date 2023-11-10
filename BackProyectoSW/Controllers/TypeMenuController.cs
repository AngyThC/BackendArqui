using BackProyectoSW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;

namespace BackProyectoSW.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods:"GET, POST, PUT, DELETE, OPTIONS")]
    public class TypeMenuController : ApiController
    {
        // GET: api/TypeMenu
        public IEnumerable<TypeMenu> Get()
        {
            TypeMenuManager managerMenu = new TypeMenuManager();
            //llamar metodo del modelo
            return managerMenu.getTypeMenu();
        }

        // GET: api/TypeMenu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TypeMenu
        public bool Post([FromBody]TypeMenu MenuT)
        {
            TypeMenuManager managerMenu = new TypeMenuManager();
            //llamar metodo del modelo
            bool res = managerMenu.AddTypeMenu(MenuT);

            return res;
        }

        // PUT: api/TypeMenu/5
        public bool Put(int id, [FromBody]TypeMenu MenuT)
        {
            TypeMenuManager managerMenu = new TypeMenuManager();
            //llamar metodo del modelo
            bool res = managerMenu.UpdateTypeMenu(id,MenuT);

            return res;
        }

        // DELETE: api/TypeMenu/5
        public bool Delete(int id)
        {
            TypeMenuManager managerMenu = new TypeMenuManager();
            //llamar metodo del modelo
            bool res = managerMenu.DeleteTypeMenu(id);

            return res;
        }
    }
}
