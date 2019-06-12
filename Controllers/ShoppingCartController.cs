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
    public class ShoppingCartController : Controller
    {
        private MongoCon _dbcontext;
        private IMongoCollection<ShoppingCartModel> cartsCollection;
        // GET: Carrito_Compras
        public ActionResult Index()
        {
            return View();
        }

        // GET: Carrito_Compras/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carrito_Compras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito_Compras/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrito_Compras/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito_Compras/Edit/5
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

        // GET: Carrito_Compras/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrito_Compras/Delete/5
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
