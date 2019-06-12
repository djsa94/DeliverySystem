using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoProgramado3.Controllers
{
    public class Sitio_productoController : Controller
    {
        // GET: Sitio_producto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sitio_producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sitio_producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sitio_producto/Create
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
