using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneMvc1.Controllers
{
    public class KitaplarController : BaseController
    {
        // GET: Kitaplar
        public ActionResult Index()
        {
            return View();
        }
    }
}