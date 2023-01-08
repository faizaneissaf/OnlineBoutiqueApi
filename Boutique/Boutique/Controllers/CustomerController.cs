using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Boutique.Models;

namespace Boutique.Controllers
{
    public class CustomerController : ApiController
    {
        OnlineBoutiqueEntities2 db = new OnlineBoutiqueEntities2();
        [HttpGet]
        public HttpResponseMessage stichProducts()
        {
            try
            {
                var products = db.Stich_Products.Select(x => x).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,x.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage UnstichProducts()
        {
            try
            {
                var products = db.Unstich_Products.Select(x => x).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, products);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage addGroup(Group g)
        {
            try
            {
                db.Groups.Add(g);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,"Addedd Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage allGroups(int userId)
        {
            try
            {
                var groups = db.Groups.Where(x => x.user_id==userId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, groups);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage addGroupMember(Group_Members gm)
        {
            try
            {
                db.Group_Members.Add(gm);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Addedd Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage allGroupMembers(int groupId)
        {
            try
            {
                var groupMembers = db.Group_Members.Where(x => x.g_id == groupId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, groupMembers);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage addSptoCart(Cart c)
        {
            try
            {
                db.Carts.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Addedd Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage productDetails(int pid)
        {
            try
            {
                var product = db.Stich_Products.Where(x => x.sp_id == pid).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage addOrder(Product_Orders po)
        {
            try
            {
                db.Product_Orders.Add(po);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Orderd Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage orderHistory(int userid)
        {
            try
            {
                var product = db.Product_Orders.Where(x => x.user_id == userid).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage ReOrder(int orderid)
        {
            try
            {
                var p = db.Product_Orders.FirstOrDefault(x => x.po_id == orderid);
                db.Product_Orders.Add(p);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Re-Orderd Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage RecomendProduct(Recomended_Products r)
        {
            try
            {
                
                db.Recomended_Products.Add(r);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Recomended Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }

    }
}
