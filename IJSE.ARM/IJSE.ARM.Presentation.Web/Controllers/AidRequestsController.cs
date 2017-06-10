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
    public class AidRequestsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AidRequests
        public ActionResult Index()
        {
            var aidRequest = db.AidRequest.Include(a => a.DisasterMaster).Include(a => a.Family);
            return View(aidRequest.ToList());
        }

        // GET: AidRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidRequest aidRequest = db.AidRequest.Find(id);
            if (aidRequest == null)
            {
                return HttpNotFound();
            }
            return View(aidRequest);
        }

        // GET: AidRequests/Create
        public ActionResult Create()
        {
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description");
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address");
            return View();
        }

        // POST: AidRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Date,FamilyId,DisasterMasterId,ImagePathRef,Status")] AidRequest aidRequest)
        {
            if (ModelState.IsValid)
            {
                db.AidRequest.Add(aidRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", aidRequest.DisasterMasterId);
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address", aidRequest.FamilyId);
            return View(aidRequest);
        }

        // GET: AidRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidRequest aidRequest = db.AidRequest.Find(id);
            if (aidRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", aidRequest.DisasterMasterId);
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address", aidRequest.FamilyId);
            return View(aidRequest);
        }

        // POST: AidRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Date,FamilyId,DisasterMasterId,ImagePathRef,Status")] AidRequest aidRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aidRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", aidRequest.DisasterMasterId);
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address", aidRequest.FamilyId);
            return View(aidRequest);
        }

        // GET: AidRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidRequest aidRequest = db.AidRequest.Find(id);
            if (aidRequest == null)
            {
                return HttpNotFound();
            }
            return View(aidRequest);
        }

        // POST: AidRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AidRequest aidRequest = db.AidRequest.Find(id);
            db.AidRequest.Remove(aidRequest);
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
