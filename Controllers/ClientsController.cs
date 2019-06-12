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

namespace ProyectoProgramado3.Controllers
{
    public class ClientsController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<ClientModel> clientsCollection;

        public ClientsController()
        {
            _dbcontext = new MongoCon();
        }

            // GET: Clientes
            public ActionResult Index()
        {
            clientsCollection = _dbcontext.database.GetCollection<ClientModel>("Clients");
            var clients = clientsCollection.AsQueryable<ClientModel>().ToList<ClientModel>();
            List<ClientModel> list = new List<ClientModel>();
            //list.Add(sitios);
            return View(clients);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(string id)
        {
            var ClientsDetails = _dbcontext.database.GetCollection<ClientModel>("Clients");
           // var cliente = new ObjectId(id);
            var clientId = ClientsDetails.AsQueryable<ClientModel>().SingleOrDefault(x => x.idClient == id);
            return View(clientId);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClientModel collection)
        {
            clientsCollection = _dbcontext.database.GetCollection<ClientModel>("Clients");
            clientsCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            clientsCollection = _dbcontext.database.GetCollection<ClientModel>("Clients");
            //var clienteId = new ObjectId(id);
            var client = clientsCollection.AsQueryable<ClientModel>().SingleOrDefault(x => x.idClient == id);
            return View(client);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ClientModel collection)
        {
            try
            {
                clientsCollection = _dbcontext.database.GetCollection<ClientModel>("Clients");
                clientsCollection.DeleteOne(Builders<ClientModel>.Filter.Eq("idClient", id));
                Create(collection);
                var filter = Builders<ClientModel>.Filter.Eq("idClient", id);
                var update = Builders<ClientModel>.Update.Set("Name", collection.Name);//Se puede agregar mas haciendo un .Set("",) extra
                var result = clientsCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            clientsCollection = _dbcontext.database.GetCollection<ClientModel>("Clients");
            //var clienteId = new ObjectId(id);
            var client = clientsCollection.AsQueryable<ClientModel>().SingleOrDefault(x => x.idClient == id);
            return View(client);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ClientModel collection)
        {
            try
            {
                clientsCollection = _dbcontext.database.GetCollection<ClientModel>("Clients");
                clientsCollection.DeleteOne(Builders<ClientModel>.Filter.Eq("idClient", id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
