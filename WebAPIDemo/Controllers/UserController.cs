using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace WebAPIDemo.Controllers
{
    [System.Web.Http.Authorize] // 🔒 Requires authentication token
    [System.Web.Http.RoutePrefix("api/users")]

    public class UserController : ApiController
    {
        private DB1Entities1 db = new DB1Entities1();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getall")]
        public IHttpActionResult GetUsers()
        {
            var users = db.usersTables.ToList();
            return Ok(users);
        }
    }
}