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
    public class AGOfficesController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: AGOffices
        public ActionResult Index()
        {
            var aGOffice = db.AGOffice.Include(a => a.District);
            return View(aGOffice.ToList());
        }

        // GET: AGOffices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGOffice aGOffice = db.AGOffice.Find(id);
            if (aGOffice == null)
            {
                return HttpNotFound();
            }
            return View(aGOffice);
        }

        // GET: AGOffices/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.District, "Id", "Name");
            return View();
        }

        // POST: AGOffices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DistrictId")] AGOffice aGOffice)
        {
            if (ModelState.IsValid)
            {
                db.AGOffice.Add(aGOffice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.District, "Id", "Name", aGOffice.DistrictId);
            return View(aGOffice);
        }

        // GET: AGOffices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGOffice aGOffice = db.AGOffice.Find(id);
            if (aGOffice == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.District, "Id", "Name", aGOffice.DistrictId);
            return View(aGOffice);
        }

        // POST: AGOffices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DistrictId")] AGOffice aGOffice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGOffice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.District, "Id", "Name", aGOffice.DistrictId);
            return View(aGOffice);
        }

        // GET: AGOffices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGOffice aGOffice = db.AGOffice.Find(id);
            if (aGOffice == null)
            {
                return HttpNotFound();
            }
            return View(aGOffice);
        }

        // POST: AGOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AGOffice aGOffice = db.AGOffice.Find(id);
            db.AGOffice.Remove(aGOffice);
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
