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
        public ActionResult KitaplariGoster()
        {
            return View();
        }
        public ActionResult TakvimiGoster()
        {
            return View();
        }
        public ActionResult PopulerleriGoster()
        {
            return View();
        }
        public ActionResult BildirimleriGoster()
        {
            return View();
        }
        public ActionResult Hakkinda()
        {
            return View();
        }
        
    }
}