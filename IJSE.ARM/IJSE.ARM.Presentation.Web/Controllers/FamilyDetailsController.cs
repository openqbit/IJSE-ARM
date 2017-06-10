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
    public class FamilyDetailsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: FamilyDetails
        public ActionResult Index()
        {
            var familyDetail = db.FamilyDetail.Include(f => f.Family).Include(f => f.Person);
            return View(familyDetail.ToList());
        }

        // GET: FamilyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyDetail familyDetail = db.FamilyDetail.Find(id);
            if (familyDetail == null)
            {
                return HttpNotFound();
            }
            return View(familyDetail);
        }

        // GET: FamilyDetails/Create
        public ActionResult Create()
        {
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address");
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC");
            return View();
        }

        // POST: FamilyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,IsPrimaryMember,FamilyId,FamilyMemeberType")] FamilyDetail familyDetail)
        {
            if (ModelState.IsValid)
            {
                db.FamilyDetail.Add(familyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address", familyDetail.FamilyId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", familyDetail.PersonId);
            return View(familyDetail);
        }

        // GET: FamilyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyDetail familyDetail = db.FamilyDetail.Find(id);
            if (familyDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address", familyDetail.FamilyId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", familyDetail.PersonId);
            return View(familyDetail);
        }

        // POST: FamilyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonId,IsPrimaryMember,FamilyId,FamilyMemeberType")] FamilyDetail familyDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(db.Family, "Id", "Address", familyDetail.FamilyId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "NIC", familyDetail.PersonId);
            return View(familyDetail);
        }

        // GET: FamilyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyDetail familyDetail = db.FamilyDetail.Find(id);
            if (familyDetail == null)
            {
                return HttpNotFound();
            }
            return View(familyDetail);
        }

        // POST: FamilyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyDetail familyDetail = db.FamilyDetail.Find(id);
            db.FamilyDetail.Remove(familyDetail);
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
