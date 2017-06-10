using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IJSE.ARM.Common.Models;
using IJSE.ARM.DataAccess.DAL;

namespace IJSE.ARM.Presentation.Web.Controllers
{
    public class DisasterTypesController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DisasterTypes
        public ActionResult Index()
        {
            return View(db.DisasterType.ToList());
        }

        // GET: DisasterTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterType disasterType = db.DisasterType.Find(id);
            if (disasterType == null)
            {
                return HttpNotFound();
            }
            return View(disasterType);
        }

        // GET: DisasterTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisasterTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DisasterType disasterType)
        {
            if (ModelState.IsValid)
            {
                db.DisasterType.Add(disasterType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disasterType);
        }

        // GET: DisasterTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterType disasterType = db.DisasterType.Find(id);
            if (disasterType == null)
            {
                return HttpNotFound();
            }
            return View(disasterType);
        }

        // POST: DisasterTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DisasterType disasterType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disasterType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disasterType);
        }

        // GET: DisasterTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterType disasterType = db.DisasterType.Find(id);
            if (disasterType == null)
            {
                return HttpNotFound();
            }
            return View(disasterType);
        }

        // POST: DisasterTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisasterType disasterType = db.DisasterType.Find(id);
            db.DisasterType.Remove(disasterType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
