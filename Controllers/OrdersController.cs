using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoProgramado3.App_Start;
using ProyectoProgramado3.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson.IO;
using Neo4j.Driver.V1;

namespace ProyectoProgramado3.Controllers
{
    public class OrdersController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<OrderModel> orderCollection;

        public OrdersController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Pedidos
        public ActionResult Index()
        {
            orderCollection = _dbcontext.database.GetCollection<OrderModel>("Orders");
            var orders = orderCollection.AsQueryable<OrderModel>().ToList<OrderModel>();
            List<OrderModel> list = new List<OrderModel>();
            //list.Add(sitios);

 //           using (var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "basesavanzadas")))
 //           using (var session = driver.Session())
 //           {
                
 //               var result = session.Run("MATCH (a:Clients),(b:Places) WHERE a.idClient = '1' AND b.idPlace = '1' CREATE (a)-[:buysAt]->(b)");

               // foreach (var record in result)
               //     Console.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
 //           }

            return View(orders);
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(string id)
        {
            var OrdersDetails = _dbcontext.database.GetCollection<OrderModel>("Orders");
            //var pedidos = new ObjectId(id);
            var ordersId = OrdersDetails.AsQueryable<OrderModel>().SingleOrDefault(x => x.idOrder == id);
            return View(ordersId);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        public ActionResult Create(OrderModel collection)
        {
            orderCollection = _dbcontext.database.GetCollection<OrderModel>("Orders");
            orderCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(string id)
        {
            orderCollection = _dbcontext.database.GetCollection<OrderModel>("Orders");
            //var pedidoId = new ObjectId(id);
            var order = orderCollection.AsQueryable<OrderModel>().SingleOrDefault(x => x.idOrder == id);
            return View(order);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, OrderModel collection)
        {
            try
            {
                orderCollection = _dbcontext.database.GetCollection<OrderModel>("Orders");
                orderCollection.DeleteOne(Builders<OrderModel>.Filter.Eq("idOrder", id));
                Create(collection);
                var filter = Builders<OrderModel>.Filter.Eq("idOrder", id);
                var update = Builders<OrderModel>.Update.Set("idOrder", collection.idOrder);//Se puede agregar mas haciendo un .Set("",) extra
                var result = orderCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(string id)
        {
            orderCollection = _dbcontext.database.GetCollection<OrderModel>("Orders");
            //var pedidosId = new ObjectId(id);
            var orders = orderCollection.AsQueryable<OrderModel>().SingleOrDefault(x => x.idOrder == id);
            return View(orders);
        }

        // POST: Pedidos/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, OrderModel collection)
        {
            try
            {

                orderCollection = _dbcontext.database.GetCollection<OrderModel>("Orders");
                orderCollection.DeleteOne(Builders<OrderModel>.Filter.Eq("idOrder", id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
