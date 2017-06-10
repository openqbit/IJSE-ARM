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
    public class GSAreasController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: GSAreas
        public ActionResult Index()
        {
            var gSArea = db.GSArea.Include(g => g.AGOffice);
            return View(gSArea.ToList());
        }

        // GET: GSAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GSArea gSArea = db.GSArea.Find(id);
            if (gSArea == null)
            {
                return HttpNotFound();
            }
            return View(gSArea);
        }

        // GET: GSAreas/Create
        public ActionResult Create()
        {
            ViewBag.AGOfficeId = new SelectList(db.AGOffice, "Id", "Name");
            return View();
        }

        // POST: GSAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AGOfficeId")] GSArea gSArea)
        {
            if (ModelState.IsValid)
            {
                db.GSArea.Add(gSArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AGOfficeId = new SelectList(db.AGOffice, "Id", "Name", gSArea.AGOfficeId);
            return View(gSArea);
        }

        // GET: GSAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GSArea gSArea = db.GSArea.Find(id);
            if (gSArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.AGOfficeId = new SelectList(db.AGOffice, "Id", "Name", gSArea.AGOfficeId);
            return View(gSArea);
        }

        // POST: GSAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AGOfficeId")] GSArea gSArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gSArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AGOfficeId = new SelectList(db.AGOffice, "Id", "Name", gSArea.AGOfficeId);
            return View(gSArea);
        }

        // GET: GSAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GSArea gSArea = db.GSArea.Find(id);
            if (gSArea == null)
            {
                return HttpNotFound();
            }
            return View(gSArea);
        }

        // POST: GSAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GSArea gSArea = db.GSArea.Find(id);
            db.GSArea.Remove(gSArea);
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
