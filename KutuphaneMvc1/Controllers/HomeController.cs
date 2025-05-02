using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneMvc1.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ProfileImage(string id)
        {
            var url = "https://drive.google.com/uc?export=download&id=" + id;
            System.Net.Http.HttpClient client = null;
            try
            {
                client = new System.Net.Http.HttpClient();
                var data = await client.GetByteArrayAsync(url);
                return File(data, "image/jpeg");
            }
            catch
            {
                var def = Server.MapPath("~/Content/images/default-profile.png");
                return File(System.IO.File.ReadAllBytes(def), "image/png");
            }
            finally
            {
                client?.Dispose();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}