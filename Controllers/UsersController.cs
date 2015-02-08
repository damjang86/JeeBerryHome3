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

            GraphClient client = GraphClientWrapper.GetInstance();
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where has(n.Username) and has(n.Name) and has(n.Surname) and has(n.ImageUrl) return n",
                                                            new Dictionary<string, object>(), CypherResultMode.Set);


            List<User> users = ((IRawGraphClient)client).ExecuteGetCypherResults<User>(query).ToList();


            List<String> lista = new List<String>();
            foreach(User user in users)
            {
                lista.Add(user.ImageUrl);
                lista.Add(user.Username);
                lista.Add(user.Name);
                lista.Add(user.Surname);
                lista.Add(user.Type);
                lista.Add(user.Validated ? "da" : "ne");
            }

            ViewBag.korisnici = lista;
            return View();
        }

        public void GetUserData(String userName)
        {
            GraphClient client = GraphClientWrapper.GetInstance();
            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where has(n.Username) and n.Username =~ \"" + userName + "\" return n",
                                                            new Dictionary<string, object>(), CypherResultMode.Set);


            List<User> users = ((IRawGraphClient)client).ExecuteGetCypherResults<User>(query).ToList();

            if (users.Count == 0)
            {
                Response.Write("error_not_existing");
            }
            else
            {
                List<String> lista = new List<String>();
                lista.Add(users[0].ImageUrl);
                lista.Add(users[0].Username);
                lista.Add(users[0].Name);
                lista.Add(users[0].Surname);
                lista.Add(users[0].Type);
                lista.Add(users[0].Validated ? "da" : "ne");

                String json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(lista);
                Response.Write(json);
            }
            
        }

        public void SaveUserData(String ime, String prezime, String korisnickoIme, String sifra, String ponovljenaSifra, String slikaUrl)
        {

            if (!sifra.Equals(ponovljenaSifra, StringComparison.OrdinalIgnoreCase))
                Response.Write("error_password");

            GraphClient client = GraphClientWrapper.GetInstance();

            User toAdd = new User();
            toAdd.Username = korisnickoIme;

            var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where has(n.Username) and n.Username =~ \"" + toAdd.Username + "\" return n",
                                                            new Dictionary<string, object>(), CypherResultMode.Set);


            List<User> users = ((IRawGraphClient)client).ExecuteGetCypherResults<User>(query).ToList();

            if (users.Count != 0)
                Response.Write("error_existing");

            // Generisanje URL-a slike
            HttpPostedFileBase userImg = Request.Files["slika"];

            if (userImg != null && userImg.ContentLength > 0)
            {
                string fileNameApplication = System.IO.Path.GetFileName(userImg.FileName);
                string fileExtensionApplication = System.IO.Path.GetExtension(fileNameApplication);

                // generating a random guid for a new file at server for the uploaded file
                string newFile = korisnickoIme + "Img" + fileExtensionApplication;
                // getting a valid server path to save
                string filePath = System.IO.Path.Combine(Server.MapPath("Content/userImgs"), newFile);

                if (fileNameApplication != String.Empty)
                {
                    userImg.SaveAs(filePath);
                    toAdd.ImageUrl = filePath;
                }
            }

            toAdd.Name = ime;
            toAdd.Surname = prezime;
            toAdd.Password = sifra;


            Dictionary<string, object> queryDict = new Dictionary<string, object>();

            queryDict.Add("Username", toAdd.Username);
            queryDict.Add("Name", toAdd.Name);
            queryDict.Add("Surname", toAdd.Surname);
            queryDict.Add("Password", toAdd.Password);
            queryDict.Add("ImageUrl", toAdd.ImageUrl);
            queryDict.Add("Validated", false);
            queryDict.Add("Type", "CLIENT");


            query = new Neo4jClient.Cypher.CypherQuery("CREATE (NewUser:User {Username:'" + toAdd.Username + "', Name:'" + toAdd.Name + "' , Surname:'" + toAdd.Surname + "', Password:'"
                                                        + toAdd.Password + "', ImageUrl:'" + toAdd.ImageUrl + "', Validated:'" + false + "', Type:'" + "CLIENT" + "'}) return NewUser",
                                                            queryDict, CypherResultMode.Set);

            users = ((IRawGraphClient)client).ExecuteGetCypherResults<User>(query).ToList();

            if (users.Count > 0)
            {
                Response.Write("done," + toAdd.ImageUrl);
            }
            else
            {
                Response.Write("error");
            }
        }
    }
}
