using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Boutique.Models;

namespace Boutique.Controllers
{
    public class UsersController : ApiController
    {
        OnlineBoutiqueEntities2 db = new OnlineBoutiqueEntities2();
        [HttpGet]
        public HttpResponseMessage Test()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Working Fine");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage Login(string email, string password)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.user_email == email && x.user_password == password);
                if (user!=null)
                {
                    if (user.user_type==0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Customer");
                    }else if (user.user_type == 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Tailor");
                    }else if (user.user_type == 2)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Admin");
                    }
                    else
                    {
                         return Request.CreateResponse(HttpStatusCode.OK, "Invalid Email/Password.");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No User Found");
                }

            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage Signup(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Registered Successfully.");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        //----Login user info 
        [HttpGet]
        public HttpResponseMessage LoginInfo(String email)
        {
            try
            {
                var data = db.Users.FirstOrDefault(x => x.user_email == email);
                var id = data.user_id;
                
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

    }
}
