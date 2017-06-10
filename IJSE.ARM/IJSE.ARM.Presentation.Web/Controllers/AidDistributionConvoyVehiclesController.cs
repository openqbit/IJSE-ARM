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
    public class AidDistributionConvoyVehiclesController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AidDistributionConvoyVehicles
        public ActionResult Index()
        {
            var aidDistributionConvoyVehicles = db.AidDistributionConvoyVehicles.Include(a => a.AidDistributionConvoy);
            return View(aidDistributionConvoyVehicles.ToList());
        }

        // GET: AidDistributionConvoyVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionConvoyVehicles aidDistributionConvoyVehicles = db.AidDistributionConvoyVehicles.Find(id);
            if (aidDistributionConvoyVehicles == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionConvoyVehicles);
        }

        // GET: AidDistributionConvoyVehicles/Create
        public ActionResult Create()
        {
            ViewBag.AidDistributionConvoyId = new SelectList(db.AidDistributionConvoy, "Id", "Root");
            return View();
        }

        // POST: AidDistributionConvoyVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AidDistributionConvoyId,VehicleNumber,VehicleType,ImagePathRef,RefNotes")] AidDistributionConvoyVehicles aidDistributionConvoyVehicles)
        {
            if (ModelState.IsValid)
            {
                db.AidDistributionConvoyVehicles.Add(aidDistributionConvoyVehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AidDistributionConvoyId = new SelectList(db.AidDistributionConvoy, "Id", "Root", aidDistributionConvoyVehicles.AidDistributionConvoyId);
            return View(aidDistributionConvoyVehicles);
        }

        // GET: AidDistributionConvoyVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionConvoyVehicles aidDistributionConvoyVehicles = db.AidDistributionConvoyVehicles.Find(id);
            if (aidDistributionConvoyVehicles == null)
            {
                return HttpNotFound();
            }
            ViewBag.AidDistributionConvoyId = new SelectList(db.AidDistributionConvoy, "Id", "Root", aidDistributionConvoyVehicles.AidDistributionConvoyId);
            return View(aidDistributionConvoyVehicles);
        }

        // POST: AidDistributionConvoyVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AidDistributionConvoyId,VehicleNumber,VehicleType,ImagePathRef,RefNotes")] AidDistributionConvoyVehicles aidDistributionConvoyVehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aidDistributionConvoyVehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AidDistributionConvoyId = new SelectList(db.AidDistributionConvoy, "Id", "Root", aidDistributionConvoyVehicles.AidDistributionConvoyId);
            return View(aidDistributionConvoyVehicles);
        }

        // GET: AidDistributionConvoyVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionConvoyVehicles aidDistributionConvoyVehicles = db.AidDistributionConvoyVehicles.Find(id);
            if (aidDistributionConvoyVehicles == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionConvoyVehicles);
        }

        // POST: AidDistributionConvoyVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AidDistributionConvoyVehicles aidDistributionConvoyVehicles = db.AidDistributionConvoyVehicles.Find(id);
            db.AidDistributionConvoyVehicles.Remove(aidDistributionConvoyVehicles);
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
