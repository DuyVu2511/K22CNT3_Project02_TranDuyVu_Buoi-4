﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CN3_TranDuyVu_Project02.Models;

namespace K22CN3_TranDuyVu_Project02.Controllers
{
    public class TDV_GAMEsController : Controller
    {
        private TDVDbEntities db = new TDVDbEntities();

        // GET: TDV_GAMEs
        public ActionResult Index()
        {
            var gAMEs = db.GAMEs.Include(g => g.LOAI_GAME);
            return View(gAMEs.ToList());
        }

        // GET: TDV_GAMEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GAME gAME = db.GAMEs.Find(id);
            if (gAME == null)
            {
                return HttpNotFound();
            }
            return View(gAME);
        }

        // GET: TDV_GAMEs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LOAI_GAME, "ID", "MaLoaiGame");
            return View();
        }

        // POST: TDV_GAMEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaGame,TenGame,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] GAME gAME)
        {
            if (ModelState.IsValid)
            {
                db.GAMEs.Add(gAME);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LOAI_GAME, "ID", "MaLoaiGame", gAME.MaLoai);
            return View(gAME);
        }

        // GET: TDV_GAMEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GAME gAME = db.GAMEs.Find(id);
            if (gAME == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LOAI_GAME, "ID", "MaLoaiGame", gAME.MaLoai);
            return View(gAME);
        }

        // POST: TDV_GAMEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaGame,TenGame,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] GAME gAME)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gAME).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LOAI_GAME, "ID", "MaLoaiGame", gAME.MaLoai);
            return View(gAME);
        }

        // GET: TDV_GAMEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GAME gAME = db.GAMEs.Find(id);
            if (gAME == null)
            {
                return HttpNotFound();
            }
            return View(gAME);
        }

        // POST: TDV_GAMEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GAME gAME = db.GAMEs.Find(id);
            db.GAMEs.Remove(gAME);
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
