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
    public class DonorPeoplesController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: DonorPeoples
        public ActionResult Index()
        {
            var donorPeople = db.DonorPeople.Include(d => d.Donor).Include(d => d.Person);
            return View(donorPeople.ToList());
        }

        // GET: DonorPeoples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorPeople donorPeople = db.DonorPeople.Find(id);
            if (donorPeople == null)
            {
                return HttpNotFound();
            }
            return View(donorPeople);
        }

        // GET: DonorPeoples/Create
        public ActionResult Create()
        {
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name");
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC");
            return View();
        }

        // POST: DonorPeoples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsPrimaryContact,DonorId,PersonId")] DonorPeople donorPeople)
        {
            if (ModelState.IsValid)
            {
                db.DonorPeople.Add(donorPeople);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donorPeople.DonorId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", donorPeople.PersonId);
            return View(donorPeople);
        }

        // GET: DonorPeoples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorPeople donorPeople = db.DonorPeople.Find(id);
            if (donorPeople == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donorPeople.DonorId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", donorPeople.PersonId);
            return View(donorPeople);
        }

        // POST: DonorPeoples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsPrimaryContact,DonorId,PersonId")] DonorPeople donorPeople)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donorPeople).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorId = new SelectList(db.Donor, "Id", "Name", donorPeople.DonorId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", donorPeople.PersonId);
            return View(donorPeople);
        }

        // GET: DonorPeoples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonorPeople donorPeople = db.DonorPeople.Find(id);
            if (donorPeople == null)
            {
                return HttpNotFound();
            }
            return View(donorPeople);
        }

        // POST: DonorPeoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonorPeople donorPeople = db.DonorPeople.Find(id);
            db.DonorPeople.Remove(donorPeople);
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
