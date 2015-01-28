using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeeBerryHome3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
 
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserProfile()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PreviousExams()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        
        public ActionResult Messages()
        {
            ViewBag.Message = "Your contact page.";
            return View();

            
        }
        
        String blah(String a, String h)
        {
            return "MH";
        }
    }
}
