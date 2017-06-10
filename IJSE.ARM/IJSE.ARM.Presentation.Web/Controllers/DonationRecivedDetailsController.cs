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
    public class DonationRecivedDetailsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DonationRecivedDetails
        public ActionResult Index()
        {
            var donationRecivedDetail = db.DonationRecivedDetail.Include(d => d.AidItem).Include(d => d.DonationRecived);
            return View(donationRecivedDetail.ToList());
        }

        // GET: DonationRecivedDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecivedDetail donationRecivedDetail = db.DonationRecivedDetail.Find(id);
            if (donationRecivedDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationRecivedDetail);
        }

        // GET: DonationRecivedDetails/Create
        public ActionResult Create()
        {
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name");
            ViewBag.DonationRecivedId = new SelectList(db.DonationRecived, "Id", "Description");
            return View();
        }

        // POST: DonationRecivedDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonationRecivedId,AidItemId,Qty,ImagePathRef,RefNotes")] DonationRecivedDetail donationRecivedDetail)
        {
            if (ModelState.IsValid)
            {
                db.DonationRecivedDetail.Add(donationRecivedDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", donationRecivedDetail.AidItemId);
            ViewBag.DonationRecivedId = new SelectList(db.DonationRecived, "Id", "Description", donationRecivedDetail.DonationRecivedId);
            return View(donationRecivedDetail);
        }

        // GET: DonationRecivedDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecivedDetail donationRecivedDetail = db.DonationRecivedDetail.Find(id);
            if (donationRecivedDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", donationRecivedDetail.AidItemId);
            ViewBag.DonationRecivedId = new SelectList(db.DonationRecived, "Id", "Description", donationRecivedDetail.DonationRecivedId);
            return View(donationRecivedDetail);
        }

        // POST: DonationRecivedDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonationRecivedId,AidItemId,Qty,ImagePathRef,RefNotes")] DonationRecivedDetail donationRecivedDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationRecivedDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", donationRecivedDetail.AidItemId);
            ViewBag.DonationRecivedId = new SelectList(db.DonationRecived, "Id", "Description", donationRecivedDetail.DonationRecivedId);
            return View(donationRecivedDetail);
        }

        // GET: DonationRecivedDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationRecivedDetail donationRecivedDetail = db.DonationRecivedDetail.Find(id);
            if (donationRecivedDetail == null)
            {
                return HttpNotFound();
            }
            return View(donationRecivedDetail);
        }

        // POST: DonationRecivedDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationRecivedDetail donationRecivedDetail = db.DonationRecivedDetail.Find(id);
            db.DonationRecivedDetail.Remove(donationRecivedDetail);
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
