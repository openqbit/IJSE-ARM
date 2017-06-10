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
    public class AidDistributionConvoysController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AidDistributionConvoys
        public ActionResult Index()
        {
            var aidDistributionConvoy = db.AidDistributionConvoy.Include(a => a.AidDistribution);
            return View(aidDistributionConvoy.ToList());
        }

        // GET: AidDistributionConvoys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionConvoy aidDistributionConvoy = db.AidDistributionConvoy.Find(id);
            if (aidDistributionConvoy == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionConvoy);
        }

        // GET: AidDistributionConvoys/Create
        public ActionResult Create()
        {
            ViewBag.AidDistributionId = new SelectList(db.AidDistribution, "Id", "ImagePathRef");
            return View();
        }

        // POST: AidDistributionConvoys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AidDistributionId,TotalVehicles,Root,GPSLocations,ImagePathRef,RefNotes")] AidDistributionConvoy aidDistributionConvoy)
        {
            if (ModelState.IsValid)
            {
                db.AidDistributionConvoy.Add(aidDistributionConvoy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AidDistributionId = new SelectList(db.AidDistribution, "Id", "ImagePathRef", aidDistributionConvoy.AidDistributionId);
            return View(aidDistributionConvoy);
        }

        // GET: AidDistributionConvoys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionConvoy aidDistributionConvoy = db.AidDistributionConvoy.Find(id);
            if (aidDistributionConvoy == null)
            {
                return HttpNotFound();
            }
            ViewBag.AidDistributionId = new SelectList(db.AidDistribution, "Id", "ImagePathRef", aidDistributionConvoy.AidDistributionId);
            return View(aidDistributionConvoy);
        }

        // POST: AidDistributionConvoys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AidDistributionId,TotalVehicles,Root,GPSLocations,ImagePathRef,RefNotes")] AidDistributionConvoy aidDistributionConvoy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aidDistributionConvoy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AidDistributionId = new SelectList(db.AidDistribution, "Id", "ImagePathRef", aidDistributionConvoy.AidDistributionId);
            return View(aidDistributionConvoy);
        }

        // GET: AidDistributionConvoys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionConvoy aidDistributionConvoy = db.AidDistributionConvoy.Find(id);
            if (aidDistributionConvoy == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionConvoy);
        }

        // POST: AidDistributionConvoys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AidDistributionConvoy aidDistributionConvoy = db.AidDistributionConvoy.Find(id);
            db.AidDistributionConvoy.Remove(aidDistributionConvoy);
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
