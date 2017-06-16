﻿using System;
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
    [Authorize]
    public class DistrictsController : Controller
    {
        private ARMContext db = new ARMContext();

        // GET: Districts
        public ActionResult Index()
        {
            var district = db.District.Include(d => d.Province);
            return View(district.ToList());
        }

        // GET: Districts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.District.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

   
        // GET: Districts/Create
        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Province, "Id", "Name");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ProvinceId")] District district)
        {
            if (ModelState.IsValid)
            {
                db.District.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(db.Province, "Id", "Name", district.ProvinceId);
            return View(district);
        }

        // GET: Districts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.District.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Province, "Id", "Name", district.ProvinceId);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ProvinceId")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(db.Province, "Id", "Name", district.ProvinceId);
            return View(district);
        }

        // GET: Districts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.District.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.District.Find(id);
            db.District.Remove(district);
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
