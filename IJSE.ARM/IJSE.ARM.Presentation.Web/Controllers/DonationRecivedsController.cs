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
    public class DonationRecivedsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DonationReciveds
        public ActionResult Index()
        {
            var donationRecived = db.DonationRecived.Include(d => d.AcceptedOfficer).Include(d => d.DonationRequest);
            return View(donationRecived.ToList());
        }

        // GET: DonationReciveds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecived donationRecived = db.DonationRecived.Find(id);
            if (donationRecived == null)
            {
                return HttpNotFound();
            }
            return View(donationRecived);
        }

        // GET: DonationReciveds/Create
        public ActionResult Create()
        {
            ViewBag.AcceptedOfficerId = new SelectList(db.Person, "PersonId", "NIC");
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description");
            return View();
        }

        // POST: DonationReciveds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Date,DonationRequestId,ImagePathRef,RefNotes,AcceptedOfficerId,Status")] DonationRecived donationRecived)
        {
            if (ModelState.IsValid)
            {
                db.DonationRecived.Add(donationRecived);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcceptedOfficerId = new SelectList(db.Person, "PersonId", "NIC", donationRecived.AcceptedOfficerId);
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description", donationRecived.DonationRequestId);
            return View(donationRecived);
        }

        // GET: DonationReciveds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecived donationRecived = db.DonationRecived.Find(id);
            if (donationRecived == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcceptedOfficerId = new SelectList(db.Person, "PersonId", "NIC", donationRecived.AcceptedOfficerId);
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description", donationRecived.DonationRequestId);
            return View(donationRecived);
        }

        // POST: DonationReciveds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Date,DonationRequestId,ImagePathRef,RefNotes,AcceptedOfficerId,Status")] DonationRecived donationRecived)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationRecived).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcceptedOfficerId = new SelectList(db.Person, "PersonId", "NIC", donationRecived.AcceptedOfficerId);
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description", donationRecived.DonationRequestId);
            return View(donationRecived);
        }

        // GET: DonationReciveds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecived donationRecived = db.DonationRecived.Find(id);
            if (donationRecived == null)
            {
                return HttpNotFound();
            }
            return View(donationRecived);
        }

        // POST: DonationReciveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationRecived donationRecived = db.DonationRecived.Find(id);
            db.DonationRecived.Remove(donationRecived);
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
