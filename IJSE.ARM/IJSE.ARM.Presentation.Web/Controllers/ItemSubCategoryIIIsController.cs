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
    public class ItemSubCategoryIIIsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: ItemSubCategoryIIIs
        public ActionResult Index()
        {
            var itemSubCategoryIII = db.ItemSubCategoryIII.Include(i => i.ItemSubCategory);
            return View(itemSubCategoryIII.ToList());
        }

        // GET: ItemSubCategoryIIIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCategoryIII itemSubCategoryIII = db.ItemSubCategoryIII.Find(id);
            if (itemSubCategoryIII == null)
            {
                return HttpNotFound();
            }
            return View(itemSubCategoryIII);
        }

        // GET: ItemSubCategoryIIIs/Create
        public ActionResult Create()
        {
            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryII, "Id", "Name");
            return View();
        }

        // POST: ItemSubCategoryIIIs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ItemSubCategoryId")] ItemSubCategoryIII itemSubCategoryIII)
        {
            if (ModelState.IsValid)
            {
                db.ItemSubCategoryIII.Add(itemSubCategoryIII);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryII, "Id", "Name", itemSubCategoryIII.ItemSubCategoryId);
            return View(itemSubCategoryIII);
        }

        // GET: ItemSubCategoryIIIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCategoryIII itemSubCategoryIII = db.ItemSubCategoryIII.Find(id);
            if (itemSubCategoryIII == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryII, "Id", "Name", itemSubCategoryIII.ItemSubCategoryId);
            return View(itemSubCategoryIII);
        }

        // POST: ItemSubCategoryIIIs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ItemSubCategoryId")] ItemSubCategoryIII itemSubCategoryIII)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemSubCategoryIII).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemSubCategoryId = new SelectList(db.ItemSubCategoryII, "Id", "Name", itemSubCategoryIII.ItemSubCategoryId);
            return View(itemSubCategoryIII);
        }

        // GET: ItemSubCategoryIIIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemSubCategoryIII itemSubCategoryIII = db.ItemSubCategoryIII.Find(id);
            if (itemSubCategoryIII == null)
            {
                return HttpNotFound();
            }
            return View(itemSubCategoryIII);
        }

        // POST: ItemSubCategoryIIIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemSubCategoryIII itemSubCategoryIII = db.ItemSubCategoryIII.Find(id);
            db.ItemSubCategoryIII.Remove(itemSubCategoryIII);
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
