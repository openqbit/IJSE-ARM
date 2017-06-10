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
    public class DisasterMastersController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DisasterMasters
        public ActionResult Index()
        {
            var disasterMaster = db.DisasterMaster.Include(d => d.DisasterType);
            return View(disasterMaster.ToList());
        }

        // GET: DisasterMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterMaster disasterMaster = db.DisasterMaster.Find(id);
            if (disasterMaster == null)
            {
                return HttpNotFound();
            }
            return View(disasterMaster);
        }

        // GET: DisasterMasters/Create
        public ActionResult Create()
        {
            ViewBag.DisasterTypeId = new SelectList(db.DisasterType, "Id", "Name");
            return View();
        }

        // POST: DisasterMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Date,DisasterTypeId")] DisasterMaster disasterMaster)
        {
            if (ModelState.IsValid)
            {
                db.DisasterMaster.Add(disasterMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DisasterTypeId = new SelectList(db.DisasterType, "Id", "Name", disasterMaster.DisasterTypeId);
            return View(disasterMaster);
        }

        // GET: DisasterMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterMaster disasterMaster = db.DisasterMaster.Find(id);
            if (disasterMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisasterTypeId = new SelectList(db.DisasterType, "Id", "Name", disasterMaster.DisasterTypeId);
            return View(disasterMaster);
        }

        // POST: DisasterMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Date,DisasterTypeId")] DisasterMaster disasterMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disasterMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DisasterTypeId = new SelectList(db.DisasterType, "Id", "Name", disasterMaster.DisasterTypeId);
            return View(disasterMaster);
        }

        // GET: DisasterMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisasterMaster disasterMaster = db.DisasterMaster.Find(id);
            if (disasterMaster == null)
            {
                return HttpNotFound();
            }
            return View(disasterMaster);
        }

        // POST: DisasterMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisasterMaster disasterMaster = db.DisasterMaster.Find(id);
            db.DisasterMaster.Remove(disasterMaster);
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
