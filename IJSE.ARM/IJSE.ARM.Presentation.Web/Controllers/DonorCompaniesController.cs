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
    public class DonorCompaniesController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DonorCompanies
        public ActionResult Index()
        {
            var donorCompany = db.DonorCompany.Include(d => d.Company).Include(d => d.Donor);
            return View(donorCompany.ToList());
        }

        // GET: DonorCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorCompany donorCompany = db.DonorCompany.Find(id);
            if (donorCompany == null)
            {
                return HttpNotFound();
            }
            return View(donorCompany);
        }

        // GET: DonorCompanies/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name");
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name");
            return View();
        }

        // POST: DonorCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DonorId,CompanyId")] DonorCompany donorCompany)
        {
            if (ModelState.IsValid)
            {
                db.DonorCompany.Add(donorCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name", donorCompany.CompanyId);
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donorCompany.DonorId);
            return View(donorCompany);
        }

        // GET: DonorCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorCompany donorCompany = db.DonorCompany.Find(id);
            if (donorCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name", donorCompany.CompanyId);
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donorCompany.DonorId);
            return View(donorCompany);
        }

        // POST: DonorCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DonorId,CompanyId")] DonorCompany donorCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Company, "Id", "Name", donorCompany.CompanyId);
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donorCompany.DonorId);
            return View(donorCompany);
        }

        // GET: DonorCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorCompany donorCompany = db.DonorCompany.Find(id);
            if (donorCompany == null)
            {
                return HttpNotFound();
            }
            return View(donorCompany);
        }

        // POST: DonorCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorCompany donorCompany = db.DonorCompany.Find(id);
            db.DonorCompany.Remove(donorCompany);
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
