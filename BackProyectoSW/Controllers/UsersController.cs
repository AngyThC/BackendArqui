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
    public class UsersController : ApiController
    {
        //GET
        public IEnumerable<Users> Get()
        {
            UsersManager usersmanager = new UsersManager();
            //llamar metodo del modelo
            return usersmanager.GetUsers();
        }

        [Route("api/Users/GetRoles")]
        [HttpGet]
        public IHttpActionResult GetRoles()
        {
            UsersManager userManager = new UsersManager();
            List<Role> typesRol= userManager.GetRol();

            if (typesRol == null || typesRol.Count == 0)
            {
                return NotFound();
            }

            return Ok(typesRol);
        }

        [Route("api/Users/GetUserData")]
        [HttpPost] // Cambia de GET a POST
        public IHttpActionResult GetUserData([FromBody] Users users) // Cambia de [FromUri] a [FromBody]
        {
            UsersManager userManager = new UsersManager();
            List<Users> user = userManager.GetLog(users);

            if (user == null || user.Count == 0)
            {
                return NotFound();
            }

            return Ok(user);
        }




        //POST
        public bool Post([FromBody] Users users)
        {
            UsersManager usersmanager = new UsersManager();
            // llamar método del modelo
            bool res = usersmanager.AddUsers(users);

            return res;
        }

        //UPDATE
        public bool Put(int id, [FromBody] Users users)
        {
            UsersManager usersmanager = new UsersManager();
            //llamar metodo del modelo
            bool res = usersmanager.UpdateUsers(id, users);

            return res;
        }

        //DELETE
        public bool Delete(int id)
        {
            UsersManager usersmanager = new UsersManager();
            //llamar metodo del modelo
            bool res = usersmanager.DeleteUsers(id);

            return res;
        }
    }
}