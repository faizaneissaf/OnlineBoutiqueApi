using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Boutique.Models;

namespace Boutique.Controllers
{
    public class AdminController : ApiController
    {
        OnlineBoutiqueEntities2 db = new OnlineBoutiqueEntities2();
        //---Add Stich Product 
        [HttpPost]
        public HttpResponseMessage addStichProduct(Stich_Products sp)
        {
            try
            {
                //var request = HttpContext.Current.Request;
                //var photo = request.Files[0];


                /////-----Decode
                var base64StringImage = sp.sp_image;

                byte[] data = Convert.FromBase64String(base64StringImage);

                string decodedString = Encoding.UTF8.GetString(data);



                String path = HttpContext.Current.Server.MapPath("~/Content/Images/"); //Path

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }
                var check = db.Stich_Products.Select(x => x).ToList();
                int id = 1;
                
                //id++;
                //if (check.Count()!=0)
                //{
                //    id = db.Stich_Products.Max(i => i.sp_id);
                //    id++;
                //}
                Random r = new Random();
                string imageName = "IMG"+r.Next() + ".jpg";

                //set the image path
                string imgPath = Path.Combine(path, imageName);

                byte[] imageBytes = Convert.FromBase64String(base64StringImage);

                File.WriteAllBytes(imgPath, imageBytes);

                sp.sp_image = "/Content/Images/"+imageName;

                db.Stich_Products.Add(sp);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        //---Add Stich Product 
        [HttpPost]
        public HttpResponseMessage addunStichProduct(Unstich_Products unsp)
        {
            try
            {

                var base64StringImage = unsp.usp_image;

                byte[] data = Convert.FromBase64String(base64StringImage);

                string decodedString = Encoding.UTF8.GetString(data);



                String path = HttpContext.Current.Server.MapPath("~/Content/Images/"); //Path

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }
                var check = db.Stich_Products.Select(x => x).ToList();
                int id = 1;

                //id++;
                //if (check.Count() != 0)
                //{
                //    id = db.Stich_Products.Max(i => i.sp_id);
                //    id++;
                //}
                Random r = new Random();
                string imageName = "IMG" + r.Next() + ".jpg";

                //set the image path
                string imgPath = Path.Combine(path, imageName);

                byte[] imageBytes = Convert.FromBase64String(base64StringImage);

                File.WriteAllBytes(imgPath, imageBytes);

                unsp.usp_image = "/Content/Images/" + imageName;





                db.Unstich_Products.Add(unsp);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
        //---All users
        [HttpGet]
        public HttpResponseMessage getAllusers()
        {
            try
            {
                var users = db.Users.Select(x => x).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception x)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, x.Message);
            }
        }
    }
}
