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
    public class AidRequestDetailsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AidRequestDetails
        public ActionResult Index()
        {
            var aidRequestDetail = db.AidRequestDetail.Include(a => a.AidItem).Include(a => a.Person);
            return View(aidRequestDetail.ToList());
        }

        // GET: AidRequestDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidRequestDetail aidRequestDetail = db.AidRequestDetail.Find(id);
            if (aidRequestDetail == null)
            {
                return HttpNotFound();
            }
            return View(aidRequestDetail);
        }

        // GET: AidRequestDetails/Create
        public ActionResult Create()
        {
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name");
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC");
            return View();
        }

        // POST: AidRequestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,AidItemId,Qty")] AidRequestDetail aidRequestDetail)
        {
            if (ModelState.IsValid)
            {
                db.AidRequestDetail.Add(aidRequestDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", aidRequestDetail.AidItemId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", aidRequestDetail.PersonId);
            return View(aidRequestDetail);
        }

        // GET: AidRequestDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidRequestDetail aidRequestDetail = db.AidRequestDetail.Find(id);
            if (aidRequestDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", aidRequestDetail.AidItemId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", aidRequestDetail.PersonId);
            return View(aidRequestDetail);
        }

        // POST: AidRequestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonId,AidItemId,Qty")] AidRequestDetail aidRequestDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aidRequestDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AidItemId = new SelectList(db.Item, "Id", "Name", aidRequestDetail.AidItemId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", aidRequestDetail.PersonId);
            return View(aidRequestDetail);
        }

        // GET: AidRequestDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidRequestDetail aidRequestDetail = db.AidRequestDetail.Find(id);
            if (aidRequestDetail == null)
            {
                return HttpNotFound();
            }
            return View(aidRequestDetail);
        }

        // POST: AidRequestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AidRequestDetail aidRequestDetail = db.AidRequestDetail.Find(id);
            db.AidRequestDetail.Remove(aidRequestDetail);
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
