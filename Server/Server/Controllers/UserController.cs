using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class UserController : ApiController
    {


        [HttpPost()]
        [ActionName("login")]
        public HttpResponseMessage login([FromBody]String username ,  String password) {

            using (multimediaEntities entities = new multimediaEntities ()) {
                user user = entities.users.ToList().Find(u => u.username == username);
                if (user == null || user.password != password)
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User Not Found");

                return Request.CreateResponse(HttpStatusCode.OK, user);
                  
                
            }
               
        }

    }
}
