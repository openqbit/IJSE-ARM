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
    public class AidDistributionItemDetailsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AidDistributionItemDetails
        public ActionResult Index()
        {
            return View(db.AidDistributionItemDetail.ToList());
        }

        // GET: AidDistributionItemDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionItemDetail aidDistributionItemDetail = db.AidDistributionItemDetail.Find(id);
            if (aidDistributionItemDetail == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionItemDetail);
        }

        // GET: AidDistributionItemDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AidDistributionItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AidDistributionId")] AidDistributionItemDetail aidDistributionItemDetail)
        {
            if (ModelState.IsValid)
            {
                db.AidDistributionItemDetail.Add(aidDistributionItemDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aidDistributionItemDetail);
        }

        // GET: AidDistributionItemDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionItemDetail aidDistributionItemDetail = db.AidDistributionItemDetail.Find(id);
            if (aidDistributionItemDetail == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionItemDetail);
        }

        // POST: AidDistributionItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AidDistributionId")] AidDistributionItemDetail aidDistributionItemDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aidDistributionItemDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aidDistributionItemDetail);
        }

        // GET: AidDistributionItemDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AidDistributionItemDetail aidDistributionItemDetail = db.AidDistributionItemDetail.Find(id);
            if (aidDistributionItemDetail == null)
            {
                return HttpNotFound();
            }
            return View(aidDistributionItemDetail);
        }

        // POST: AidDistributionItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AidDistributionItemDetail aidDistributionItemDetail = db.AidDistributionItemDetail.Find(id);
            db.AidDistributionItemDetail.Remove(aidDistributionItemDetail);
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
