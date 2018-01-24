using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            SessionVM vm = new SessionVM();
            vm.Old = (int)Session["counter"];
            Session["counter"]= (int)Session["counter"] + 1;
            vm.New = (int)Session["counter"];
            vm.SessionID = Session.SessionID;
            
            return View(vm);
        }
    }
}