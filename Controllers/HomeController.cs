using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neo4jClient.Cypher;
using Neo4jClient;
using JeeBerryHome3.Models;

namespace JeeBerryHome3.Controllers
{
    public class HomeController : Controller
    {
        public GraphClient client;
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

            client = new GraphClient(new Uri("http://localhost:7474/db/data"));
            client.Connect();

            Band band = new Band();
            band.Name = "Amadeus";
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("name", band.Name);

            var query = new Neo4jClient.Cypher.CypherQuery("CREATE (NewBand:Band {name:'" + band.Name + "'}) return NewBand",
                                                            queryDict, CypherResultMode.Set);

            List<Band> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Band>(query).ToList();

            return View();

            
        }
        
        String blah(String a, String h)
        {
            return "MH";
        }
    }
}
