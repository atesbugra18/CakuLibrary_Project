using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Utils;
using KutuphaneMvc1.Utils;

namespace KutuphaneMvc1.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.KullaniciAdi = Session["AdSoyad"];
            ViewBag.ProfilFoto = Session["ProfilFoto"] ?? "1V0D5RuFtzGJTmrc1v-UEmHxbQeAHr8nD";
            ViewBag.Rolu = Session["Rolu"];
        }
    }
}