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
using System.Web.Http.Cors;

namespace ProyectoProgramado3.Controllers
{
   
    public class PlacesController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<PlaceModel> placesCollection;

        string globalId;

        public PlacesController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Sitios
        public ActionResult Index()
        {
            placesCollection = _dbcontext.database.GetCollection<PlaceModel>("Places");
            var places = placesCollection.AsQueryable<PlaceModel>().ToList<PlaceModel>();
            List<PlaceModel> list = new List<PlaceModel>();
            //list.Add(sitios);
            return View(places);
        }

        // GET: Sitios/Details/5
        public ActionResult Details(string id)
        {
            var PlacesDetails = _dbcontext.database.GetCollection<PlaceModel>("Places");
           // var places = new ObjectId(id);
            var placesid = PlacesDetails.AsQueryable<PlaceModel>().SingleOrDefault(x => x.idPlace == id);
            return View(placesid);
        }

        // GET: Sitios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sitios/Create
        [HttpPost]
        public ActionResult Create(PlaceModel collection)
        {
            placesCollection = _dbcontext.database.GetCollection<PlaceModel>("Places");
            placesCollection.InsertOne(collection);
            Console.WriteLine("Insert");
            return RedirectToAction("Index");
        }

        // GET: Sitios/Edit/5
        public ActionResult Edit(string id)
        {
            placesCollection = _dbcontext.database.GetCollection<PlaceModel>("Places");
            //var PlacesId = new ObjectId(id);
            var places = placesCollection.AsQueryable<PlaceModel>().SingleOrDefault(x => x.idPlace == id);
            return View(places);
        }

        // POST: Sitios/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, PlaceModel collection)
        {
            try
            {
                placesCollection = _dbcontext.database.GetCollection<PlaceModel>("Places");
                placesCollection.DeleteOne(Builders<PlaceModel>.Filter.Eq("idPlace", id));
                Create(collection);
                var filter = Builders<PlaceModel>.Filter.Eq("idPlace", id);
                var update = Builders<PlaceModel>.Update.Set("Name", collection.Name);//Se puede agregar mas haciendo un .Set("",) extra
                var result = placesCollection.UpdateOne(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sitios/Delete/5
        public ActionResult Delete(string id)
        {
            placesCollection = _dbcontext.database.GetCollection<PlaceModel>("Places");
            //var sitiosId = new ObjectId(id);
            var places = placesCollection.AsQueryable<PlaceModel>().SingleOrDefault(x => x.idPlace == id);
            return View(places);
        }

        // POST: Sitios/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, PlaceModel collection)
        {
            try
            {
                placesCollection = _dbcontext.database.GetCollection<PlaceModel>("Places");
                placesCollection.DeleteOne(Builders<PlaceModel>.Filter.Eq("idPlace", id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult SelectProduct(string id)
        {
            var productsCollection = _dbcontext.database.GetCollection<ProductModel>("Products");
            List<ProductModel> productList = new List<ProductModel>();

            var PlacesDetails = _dbcontext.database.GetCollection<PlaceModel>("Places");
            var place = PlacesDetails.AsQueryable<PlaceModel>().SingleOrDefault(x => x.idPlace == id);
            

            foreach (var product in place.ProductList)
            {
                var foundProduct = productsCollection.AsQueryable<ProductModel>().SingleOrDefault(x => x.idProduct == product);
                productList.Add(foundProduct);
            }

            Session["PlaceId"] = id;
            return View(productList);
        }
        
        public ActionResult RemoveProduct(string id)
        {
            string placeId = (string)Session["PlaceId"];

            var PlacesDetails = _dbcontext.database.GetCollection<PlaceModel>("Places");
            var place = PlacesDetails.AsQueryable<PlaceModel>().SingleOrDefault(x => x.idPlace == placeId);

            List<string> productIdList = place.ProductList;

            productIdList.Remove(id);

            var filter = Builders<PlaceModel>.Filter.Eq("idPlace", placeId);
            var update = Builders<PlaceModel>.Update.Set("ProductList", productIdList);
            var result = PlacesDetails.UpdateOne(filter, update);

            Session["PlaceId"] = "";
           
            return RedirectToAction("Index");
        }
    }
}
