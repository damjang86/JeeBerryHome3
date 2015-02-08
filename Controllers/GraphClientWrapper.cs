using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace JeeBerryHome3.Controllers
{
    public class GraphClientWrapper
    {
        private static GraphClient client;

        public static GraphClient GetInstance()
        {
            if (client == null)
            {
                client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                client.Connect();
            }
            return client;
        }
    }
}