using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neo4jClient;
using Neo4jClient.Cypher;
using JeeBerryHome3.Models;

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

        public void SaveUserData(String ime, String prezime, String korisnickoIme, String sifra, String slikaUrl)
        {
            
        }
    }
}
