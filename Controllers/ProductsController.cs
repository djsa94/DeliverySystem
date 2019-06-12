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
    public class ProductsController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<ProductModel> prodCollection;

        public ProductsController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Producto
        public ActionResult Index()
        {
            prodCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
            var products = prodCollection.AsQueryable<ProductModel>().ToList<ProductModel>();
            List<ProductModel> list = new List<ProductModel>();
            //list.Add(sitios);
            return View(products);
        }

        // GET: Producto/Details/5
        public ActionResult Details(string id)
        {
            var ProductDetails = _dbcontext.database.GetCollection<ProductModel>("Products");
            // var cliente = new ObjectId(id);
            var productId = ProductDetails.AsQueryable<ProductModel>().SingleOrDefault(x => x.idProduct == id);
            return View(productId);
            
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductModel collection)
        {
            prodCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
            prodCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(string id)
        {
            prodCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
            //var clienteId = new ObjectId(id);
            var product = prodCollection.AsQueryable<ProductModel>().SingleOrDefault(x => x.idProduct == id);
            return View(product);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, ProductModel collection)
        {
            try
            {
                // TODO: Add update logic here
                prodCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
                prodCollection.DeleteOne(Builders<ProductModel>.Filter.Eq("idProduct", id));
                Create(collection);
                var filter = Builders<ProductModel>.Filter.Eq("idProduct", id);
                var update = Builders<ProductModel>.Update.Set("Name", collection.Name);//Se puede agregar mas haciendo un .Set("",) extra
                var result = prodCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(string id)
        {
            prodCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
            //var clienteId = new ObjectId(id);
            var product = prodCollection.AsQueryable<ProductModel>().SingleOrDefault(x => x.idProduct == id);
            return View(product);
            
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, ProductModel collection)
        {
            try
            {
                prodCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
                prodCollection.DeleteOne(Builders<ProductModel>.Filter.Eq("idProduct", id));


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
