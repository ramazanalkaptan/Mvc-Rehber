﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcRehber.Models.Context;
using MvcRehber.Models.Entities;

namespace MvcRehber.Controllers
{
    public class SehirController : Controller
    {
        private MvcRehberContext db = new MvcRehberContext();

        // GET: Sehir
        public ActionResult Index()
        {
            return View(db.Sehirler.ToList());
        }

        // GET: Sehir/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehir sehir = db.Sehirler.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // GET: Sehir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sehir/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SehirAdi,PlakaKodu")] Sehir sehir)
        {
            if (ModelState.IsValid)
            {
                db.Sehirler.Add(sehir);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sehir);
        }

        // GET: Sehir/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehir sehir = db.Sehirler.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // POST: Sehir/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SehirAdi,PlakaKodu")] Sehir sehir)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sehir).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sehir);
        }

        // GET: Sehir/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sehir sehir = db.Sehirler.Find(id);
            if (sehir == null)
            {
                return HttpNotFound();
            }
            return View(sehir);
        }

        // POST: Sehir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sehir sehir = db.Sehirler.Find(id);
            db.Sehirler.Remove(sehir);
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
