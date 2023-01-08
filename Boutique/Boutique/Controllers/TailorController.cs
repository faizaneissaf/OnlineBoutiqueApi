using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Boutique.Models;

namespace Boutique.Controllers
{
    public class TailorController : ApiController
    {
        OnlineBoutiqueEntities2 db = new OnlineBoutiqueEntities2();
        [HttpPost]
        public HttpResponseMessage addDesigner(Designer ds)
        {
            try
            {
                ds.ds_rating = 0;
                ds.ds_feedback = "--";
                db.Designers.Add(ds);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Added");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
    }
}
