using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ScrumTableController : Controller
    {
        // GET: ScrumTable
        public ActionResult Index(int projectId)
        {
            return View();
        }
    }
}