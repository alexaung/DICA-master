using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dica.Models;

namespace dica.Controllers
{
    public class JointVenturePercentageController : Controller
    {
        // GET: JointVenturePercentage
        public ActionResult Index()
        {
            List<JointVenturePercentage> jointVenturePercentages = new List<JointVenturePercentage>();
            return PartialView("Index", jointVenturePercentages);
        }

        // GET: JointVenturePercentage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JointVenturePercentage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JointVenturePercentage/Create
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

        // GET: JointVenturePercentage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JointVenturePercentage/Edit/5
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

        // GET: JointVenturePercentage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JointVenturePercentage/Delete/5
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
