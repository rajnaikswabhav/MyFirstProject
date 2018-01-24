using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            SummaryVM vm = new SummaryVM();
            vm.SessionCount =(int)Session["counter"];
            vm.ApplicationCount = (int) HttpContext.Application["counter"];
            return View(vm);
        }
    }
}