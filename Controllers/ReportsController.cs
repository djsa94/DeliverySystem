using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Neo4jClient;
using ProyectoProgramado3.Models;

namespace ProyectoProgramado3.Controllers
{
    public class ReportsController : Controller
    {

        public ActionResult OrderReport()
        {
            return View();
        }


        public ActionResult OrderReport(string reportClient)
        {
            var neo4jClient = new GraphClient(new Uri("http://localhost:7474/db/data"));
            neo4jClient.Connect();

            var orders = neo4jClient.Cypher.Match("(client:Client)-[ORDERED]-(order:Order)")
                .Where((ClientModel client) => client.idClient == reportClient)
                .Return(order => order.As<OrderModel>())
                .Results;
        
            return View(orders);
        }

        public ActionResult SiteReport(string reportSite)
        {
            var neo4jClient = new GraphClient(new Uri("http://localhost:7474/db/data"));
            neo4jClient.Connect();

            var places = neo4jClient.Cypher.Match("(place:Place)<-[r:ORDERED_FROM]-(b)")
                .Return( place => place.As<PlaceModel>() )
                .Results;

            return View(places);
        }


        public ActionResult TopReport(string reportClient)
        {
            var neo4jClient = new GraphClient(new Uri("http://localhost:7474/db/data"));
            neo4jClient.Connect();

            var placeCount = neo4jClient.Cypher
                .Match("(place:Place)<-[r:ORDERED_FROM]-(b)")
                .With("place, COUNT(r) AS count")
                .Return((place, r) => place.As<PlaceModel>())
                .OrderByDescending("count")
                .Limit(5);
            
            return View(placeCount);
        }


        public ActionResult SiteInCommon(string reportClient)
        {
            var neo4jClient = new GraphClient(new Uri("http://localhost:7474/db/data"));
            neo4jClient.Connect();

            var orders = neo4jClient.Cypher.Match("(client:Client)-[ORDERED_FROM]-(place:Place)")
                .Where((ClientModel client) => client.idClient == reportClient)
                .Return(place => place.As<PlaceModel>())
                .Results;

            return View();
        }



    }
}
