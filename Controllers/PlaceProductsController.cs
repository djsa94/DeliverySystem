using MongoDB.Bson;
using MongoDB.Driver;
using ProyectoProgramado3.App_Start;
using ProyectoProgramado3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgramado3.Controllers
{
    public class PlaceProductsController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<PlaceProductModel> ppCollection;

        public PlaceProductsController()
        {
            _dbcontext = new MongoCon();
        }

        // GET: Sitio_producto
        public ActionResult Index()
        {
            ppCollection = _dbcontext.database.GetCollection<PlaceProductModel>("PlaceProducts");
            var pps = ppCollection.AsQueryable<PlaceProductModel>().ToList<PlaceProductModel>();
            List<PlaceProductModel> list = new List<PlaceProductModel>();
            //list.Add(sitios);
            return View(pps);
            
        }

        // GET: Sitio_producto/Details/5
        public ActionResult Details(string id)
        {
            var ppDetails = _dbcontext.database.GetCollection<PlaceProductModel>("PlaceProducts");
            var cliente = new ObjectId(id);
            var ppId = ppDetails.AsQueryable<PlaceProductModel>().SingleOrDefault(x => x.Id == cliente);
            return View(ppId);
        }
        // GET: Sitio_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sitio_producto/Create
        [HttpPost]
        public ActionResult Create(PlaceProductModel collection)
        {
            try
            {
                ppCollection = _dbcontext.database.GetCollection<PlaceProductModel>("PlaceProducts");
                ppCollection.InsertOne(collection);

                var PlacesDetails = _dbcontext.database.GetCollection<PlaceModel>("Places");
                var placesid = PlacesDetails.AsQueryable<PlaceModel>().SingleOrDefault(x => x.idPlace == collection.idPlace);

                var currentProducts = placesid.ProductList;
                currentProducts.Add(collection.idProduct);

                var filter = Builders<PlaceModel>.Filter.Eq("idPlace", collection.idPlace);
                var updatePlace = Builders<PlaceModel>.Update.Set("ProductList", currentProducts);
                var finalUpdate = PlacesDetails.UpdateOne(filter, updatePlace);

                Console.WriteLine("Insert");
                return RedirectToAction("Index", "Places");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sitio_producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sitio_producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sitio_producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sitio_producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
