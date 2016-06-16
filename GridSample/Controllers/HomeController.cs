using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //return new FilePathResult("Views\\Home\\Grid.html", "text/html");
            return View("MyView");
        }
    }
}
