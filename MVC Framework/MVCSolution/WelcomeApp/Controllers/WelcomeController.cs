using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class WelcomeController:Controller
    {
        public string Index()
        {
            return "<h1>Welcome to MVC</h1>";
        }

        public string GetEmp(int? id)
        {
            return "Get Employee Details of "+id;
        }

        public ActionResult SayHello(string name)
        {
            return Content("Hello " + name);
        }

        public ActionResult Browse()
        {
            ViewBag.Message = "Hello Swabhav";
            return View();
        }

        public ActionResult DisplayEmp()
        {
            DisplayEmpVM vm = new DisplayEmpVM() { Name="Raj",Salary=15000,DateOfHire="14-April-2017"};
            return View(vm);
        }
    }
}