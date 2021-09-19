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
    public class NarodnoImesController : Controller
    {
        private Entities db = new Entities();

        // GET: NarodnoImes
        public ActionResult Index()
        {
            var narodnoImes = db.NarodnoImes.Include(n => n.Bilje);
            return View(narodnoImes.ToList());
        }

        // GET: NarodnoImes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarodnoIme narodnoIme = db.NarodnoImes.Find(id);
            if (narodnoIme == null)
            {
                return HttpNotFound();
            }
            return View(narodnoIme);
        }

        // GET: NarodnoImes/Create
        public ActionResult Create()
        {
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod");
            return View();
        }

        // POST: NarodnoImes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNarodnoIme,NarodnoIme1,IDBilje")] NarodnoIme narodnoIme)
        {
            if (ModelState.IsValid)
            {
                db.NarodnoImes.Add(narodnoIme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", narodnoIme.IDBilje);
            return View(narodnoIme);
        }

        // GET: NarodnoImes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarodnoIme narodnoIme = db.NarodnoImes.Find(id);
            if (narodnoIme == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", narodnoIme.IDBilje);
            return View(narodnoIme);
        }

        // POST: NarodnoImes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNarodnoIme,NarodnoIme1,IDBilje")] NarodnoIme narodnoIme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(narodnoIme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", narodnoIme.IDBilje);
            return View(narodnoIme);
        }

        // GET: NarodnoImes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarodnoIme narodnoIme = db.NarodnoImes.Find(id);
            if (narodnoIme == null)
            {
                return HttpNotFound();
            }
            return View(narodnoIme);
        }

        // POST: NarodnoImes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NarodnoIme narodnoIme = db.NarodnoImes.Find(id);
            db.NarodnoImes.Remove(narodnoIme);
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
