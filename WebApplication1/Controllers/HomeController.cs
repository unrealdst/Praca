using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHelloWorld _helloWorld;

        public HomeController()
        {
            
        }

        public HomeController(IHelloWorld helloWorld)
        {
            this._helloWorld = helloWorld;
        }

        public ActionResult Index()
        {
            return RedirectToAction("ProjectsList", "ProjectLists");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}