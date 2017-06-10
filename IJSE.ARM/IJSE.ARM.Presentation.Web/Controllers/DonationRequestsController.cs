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
    public class DonationRequestsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DonationRequests
        public ActionResult Index()
        {
            var donationRequest = db.DonationRequest.Include(d => d.DisasterMaster).Include(d => d.Donor);
            return View(donationRequest.ToList());
        }

        // GET: DonationRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRequest donationRequest = db.DonationRequest.Find(id);
            if (donationRequest == null)
            {
                return HttpNotFound();
            }
            return View(donationRequest);
        }

        // GET: DonationRequests/Create
        public ActionResult Create()
        {
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description");
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name");
            return View();
        }

        // POST: DonationRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Date,DisasterMasterId,DonorId,ImagePathRef,Status")] DonationRequest donationRequest)
        {
            if (ModelState.IsValid)
            {
                db.DonationRequest.Add(donationRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", donationRequest.DisasterMasterId);
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donationRequest.DonorId);
            return View(donationRequest);
        }

        // GET: DonationRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRequest donationRequest = db.DonationRequest.Find(id);
            if (donationRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", donationRequest.DisasterMasterId);
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donationRequest.DonorId);
            return View(donationRequest);
        }

        // POST: DonationRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Date,DisasterMasterId,DonorId,ImagePathRef,Status")] DonationRequest donationRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisasterMasterId = new SelectList(db.DisasterMaster, "Id", "Description", donationRequest.DisasterMasterId);
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donationRequest.DonorId);
            return View(donationRequest);
        }

        // GET: DonationRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRequest donationRequest = db.DonationRequest.Find(id);
            if (donationRequest == null)
            {
                return HttpNotFound();
            }
            return View(donationRequest);
        }

        // POST: DonationRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationRequest donationRequest = db.DonationRequest.Find(id);
            db.DonationRequest.Remove(donationRequest);
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
