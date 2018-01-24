using Master_Page_App.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Master_Page_App.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            UserVM vm = new UserVM();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(UserVM vm, string returnUrl)
        {
            AuthService service = new AuthService();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (service.CheckUser(vm))
            {
                Session["User"] = vm;
                return Redirect(returnUrl);
            }
            else
            {
                return View(vm);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}