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
    public class AidDistributionsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AidDistributions
        public ActionResult Index()
        {
            var aidDistribution = db.AidDistribution.Include(a => a.DisasterMaster).Include(a => a.OfficerInCharge);
            return View(aidDistribution.ToList());
        }

        // GET: AidDistributions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistribution aidDistribution = db.AidDistribution.Find(id);
            if (aidDistribution == null)
            {
                return HttpNotFound();
            }
            return View(aidDistribution);
        }

        // GET: AidDistributions/Create
        public ActionResult Create()
        {
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description");
            ViewBag.OfficerInChargeId = new SelectList(db.Person, "PersonId", "NIC");
            return View();
        }

        // POST: AidDistributions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ETA,DeployedDate,OfficerInChargeId,ImagePathRef,RefNotes,DisasterMasterId")] AidDistribution aidDistribution)
        {
            if (ModelState.IsValid)
            {
                db.AidDistribution.Add(aidDistribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", aidDistribution.DisasterMasterId);
            ViewBag.OfficerInChargeId = new SelectList(db.Person, "PersonId", "NIC", aidDistribution.OfficerInChargeId);
            return View(aidDistribution);
        }

        // GET: AidDistributions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistribution aidDistribution = db.AidDistribution.Find(id);
            if (aidDistribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", aidDistribution.DisasterMasterId);
            ViewBag.OfficerInChargeId = new SelectList(db.Person, "PersonId", "NIC", aidDistribution.OfficerInChargeId);
            return View(aidDistribution);
        }

        // POST: AidDistributions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ETA,DeployedDate,OfficerInChargeId,ImagePathRef,RefNotes,DisasterMasterId")] AidDistribution aidDistribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aidDistribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", aidDistribution.DisasterMasterId);
            ViewBag.OfficerInChargeId = new SelectList(db.Person, "PersonId", "NIC", aidDistribution.OfficerInChargeId);
            return View(aidDistribution);
        }

        // GET: AidDistributions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistribution aidDistribution = db.AidDistribution.Find(id);
            if (aidDistribution == null)
            {
                return HttpNotFound();
            }
            return View(aidDistribution);
        }

        // POST: AidDistributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AidDistribution aidDistribution = db.AidDistribution.Find(id);
            db.AidDistribution.Remove(aidDistribution);
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
