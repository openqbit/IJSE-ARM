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
    public class ItemSubCategoryIIsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: ItemSubCategoryIIs
        public ActionResult Index()
        {
            var itemSubCategoryII = db.ItemSubCategoryII.Include(i => i.ItemSubCategory);
            return View(itemSubCategoryII.ToList());
        }

        // GET: ItemSubCategoryIIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCategoryII itemSubCategoryII = db.ItemSubCategoryII.Find(id);
            if (itemSubCategoryII == null)
            {
                return HttpNotFound();
            }
            return View(itemSubCategoryII);
        }

        // GET: ItemSubCategoryIIs/Create
        public ActionResult Create()
        {
            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryI, "Id", "Name");
            return View();
        }

        // POST: ItemSubCategoryIIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ItemSubCategoryId")] ItemSubCategoryII itemSubCategoryII)
        {
            if (ModelState.IsValid)
            {
                db.ItemSubCategoryII.Add(itemSubCategoryII);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryI, "Id", "Name", itemSubCategoryII.ItemSubCategoryId);
            return View(itemSubCategoryII);
        }

        // GET: ItemSubCategoryIIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCategoryII itemSubCategoryII = db.ItemSubCategoryII.Find(id);
            if (itemSubCategoryII == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryI, "Id", "Name", itemSubCategoryII.ItemSubCategoryId);
            return View(itemSubCategoryII);
        }

        // POST: ItemSubCategoryIIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ItemSubCategoryId")] ItemSubCategoryII itemSubCategoryII)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemSubCategoryII).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryI, "Id", "Name", itemSubCategoryII.ItemSubCategoryId);
            return View(itemSubCategoryII);
        }

        // GET: ItemSubCategoryIIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCategoryII itemSubCategoryII = db.ItemSubCategoryII.Find(id);
            if (itemSubCategoryII == null)
            {
                return HttpNotFound();
            }
            return View(itemSubCategoryII);
        }

        // POST: ItemSubCategoryIIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSubCategoryII itemSubCategoryII = db.ItemSubCategoryII.Find(id);
            db.ItemSubCategoryII.Remove(itemSubCategoryII);
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
