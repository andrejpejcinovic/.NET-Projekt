using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgramskoInzenjerstvo.Models;

namespace ProgramskoInzenjerstvo.Controllers
{
    public class BiljeUporabasController : Controller
    {
        private Entities db = new Entities();

        // GET: BiljeUporabas
        public ActionResult Index()
        {
            var biljeUporabas = db.BiljeUporabas.Include(b => b.Bilje);
            return View(biljeUporabas.ToList());
        }

        // GET: BiljeUporabas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeUporaba biljeUporaba = db.BiljeUporabas.Find(id);
            if (biljeUporaba == null)
            {
                return HttpNotFound();
            }
            return View(biljeUporaba);
        }

        // GET: BiljeUporabas/Create
        public ActionResult Create()
        {
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod");
            return View();
        }

        // POST: BiljeUporabas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBiljeUporaba,Uporaba,IDBilje")] BiljeUporaba biljeUporaba)
        {
            if (ModelState.IsValid)
            {
                db.BiljeUporabas.Add(biljeUporaba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeUporaba.IDBilje);
            return View(biljeUporaba);
        }

        // GET: BiljeUporabas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeUporaba biljeUporaba = db.BiljeUporabas.Find(id);
            if (biljeUporaba == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeUporaba.IDBilje);
            return View(biljeUporaba);
        }

        // POST: BiljeUporabas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBiljeUporaba,Uporaba,IDBilje")] BiljeUporaba biljeUporaba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biljeUporaba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeUporaba.IDBilje);
            return View(biljeUporaba);
        }

        // GET: BiljeUporabas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeUporaba biljeUporaba = db.BiljeUporabas.Find(id);
            if (biljeUporaba == null)
            {
                return HttpNotFound();
            }
            return View(biljeUporaba);
        }

        // POST: BiljeUporabas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BiljeUporaba biljeUporaba = db.BiljeUporabas.Find(id);
            db.BiljeUporabas.Remove(biljeUporaba);
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
