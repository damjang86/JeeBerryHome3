using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JeeBerryHome3.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View();
        }

        public void GetUserData(String ime, String prezime /*itd*/)
        {
            //sliku moras ovde, samo da ti prekopitam kod
            //sad mozes sve sem slike

        }
    }
}
