using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            LoginVM user = new LoginVM {Username="xyz",Password="xyz",Status="failed" };
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(LoginVM user)
        {
            if(user.Username.Equals("admin") && user.Password.Equals("admin"))
            {
                user.Status = "Successful";
                return View(user);
            }
            else {
                user.Status = "Failed";
                return View(user);
            }
            
        }
    }
}