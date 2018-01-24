using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Master_Page_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Transaction()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "User", new { returnUrl = Request.RawUrl });
            }
            return View();
        }
    }
}