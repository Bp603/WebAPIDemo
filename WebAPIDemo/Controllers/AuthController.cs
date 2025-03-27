using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace WebAPIDemo.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController: ApiController
    {
        private DB1Entities1 db = new DB1Entities1(); // Your EDMX context class

        // ✅ REGISTER API
        [HttpPost]
        [Route("register")]
        public IHttpActionResult Register(usersTable model)
        {
            if (db.usersTables.Any(u => u.email == model.email))
            {
                return BadRequest("Email already exists.");
            }

            db.usersTables.Add(model);
            db.SaveChanges();

            return Ok("User registered successfully.");
        }

        // ✅ LOGIN API (Uses OAuth Token Authentication)
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(usersTable loginUser)
        {
            var user = db.usersTables.FirstOrDefault(u => u.email == loginUser.email && u.password == loginUser.password);

            if (user == null)
                return Unauthorized();

            return Ok("Use the /token endpoint for authentication.");
        }
    }
}