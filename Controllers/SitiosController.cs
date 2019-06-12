﻿using System;
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
    public class SitiosController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<PlaceModel> placesCollection;

        public SitiosController()
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
    }
}
