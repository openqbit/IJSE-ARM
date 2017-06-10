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
    public class DonationRequestDetailsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DonationRequestDetails
        public ActionResult Index()
        {
            var donationRequestDetail = db.DonationRequestDetail.Include(d => d.AidItem).Include(d => d.DonationRequest);
            return View(donationRequestDetail.ToList());
        }

        // GET: DonationRequestDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRequestDetail donationRequestDetail = db.DonationRequestDetail.Find(id);
            if (donationRequestDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationRequestDetail);
        }

        // GET: DonationRequestDetails/Create
        public ActionResult Create()
        {
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name");
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description");
            return View();
        }

        // POST: DonationRequestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonationRequestId,AidItemId,Qty")] DonationRequestDetail donationRequestDetail)
        {
            if (ModelState.IsValid)
            {
                db.DonationRequestDetail.Add(donationRequestDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", donationRequestDetail.AidItemId);
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description", donationRequestDetail.DonationRequestId);
            return View(donationRequestDetail);
        }

        // GET: DonationRequestDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRequestDetail donationRequestDetail = db.DonationRequestDetail.Find(id);
            if (donationRequestDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", donationRequestDetail.AidItemId);
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description", donationRequestDetail.DonationRequestId);
            return View(donationRequestDetail);
        }

        // POST: DonationRequestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonationRequestId,AidItemId,Qty")] DonationRequestDetail donationRequestDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationRequestDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", donationRequestDetail.AidItemId);
            ViewBag.DonationRequestId = new SelectList(db.DonationRequest, "Id", "Description", donationRequestDetail.DonationRequestId);
            return View(donationRequestDetail);
        }

        // GET: DonationRequestDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRequestDetail donationRequestDetail = db.DonationRequestDetail.Find(id);
            if (donationRequestDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationRequestDetail);
        }

        // POST: DonationRequestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationRequestDetail donationRequestDetail = db.DonationRequestDetail.Find(id);
            db.DonationRequestDetail.Remove(donationRequestDetail);
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
