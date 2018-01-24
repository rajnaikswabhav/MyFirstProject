using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            ApplicationVM vm = new ApplicationVM();
            if (HttpContext.Application["counter"] == null)
            {
                HttpContext.Application["counter"]=0;
            }
            vm.Old = (int)HttpContext.Application["counter"];
            HttpContext.Application["counter"]=(int)HttpContext.Application["counter"]+1;
            vm.New = (int)HttpContext.Application["counter"];
            return View(vm);
        }
    }
}