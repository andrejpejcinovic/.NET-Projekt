using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgramskoInzenjerstvo.Models;
using Rotativa;

namespace ProgramskoInzenjerstvo.Controllers
{
    public class BiljnaPutovnicasController : Controller
    {
        private Entities db = new Entities();

        // GET: BiljnaPutovnicas
        public ActionResult Index()
        {
            var biljnaPutovnicas = db.BiljnaPutovnicas.Include(b => b.Bilje);
            return View(biljnaPutovnicas.ToList());
        }

        // GET: BiljnaPutovnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljnaPutovnica biljnaPutovnica = db.BiljnaPutovnicas.Find(id);
            if (biljnaPutovnica == null)
            {
                return HttpNotFound();
            }
            
            return View(biljnaPutovnica);
        }

        // GET: BiljnaPutovnicas/Create
        public ActionResult Create()
        {
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod");
            return View();
        }

        // POST: BiljnaPutovnicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBiljnaPutovnica,Naziv,Drzava,Podrijetlo,Kod,IDBilje")] BiljnaPutovnica biljnaPutovnica)
        {
            if (ModelState.IsValid)
            {
                db.BiljnaPutovnicas.Add(biljnaPutovnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljnaPutovnica.IDBilje);
            return View(biljnaPutovnica);
        }

        // GET: BiljnaPutovnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljnaPutovnica biljnaPutovnica = db.BiljnaPutovnicas.Find(id);
            if (biljnaPutovnica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljnaPutovnica.IDBilje);
            return View(biljnaPutovnica);
        }

        // POST: BiljnaPutovnicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBiljnaPutovnica,Naziv,Drzava,Podrijetlo,Kod,IDBilje")] BiljnaPutovnica biljnaPutovnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biljnaPutovnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljnaPutovnica.IDBilje);
            return View(biljnaPutovnica);
        }

        // GET: BiljnaPutovnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljnaPutovnica biljnaPutovnica = db.BiljnaPutovnicas.Find(id);
            if (biljnaPutovnica == null)
            {
                return HttpNotFound();
            }
            return View(biljnaPutovnica);
        }

        // POST: BiljnaPutovnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BiljnaPutovnica biljnaPutovnica = db.BiljnaPutovnicas.Find(id);
            db.BiljnaPutovnicas.Remove(biljnaPutovnica);
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
        public ActionResult GetAll(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljnaPutovnica biljnaPutovnica = db.BiljnaPutovnicas.Find(id);
            if (biljnaPutovnica == null)
            {
                return HttpNotFound();
            }

            return View(biljnaPutovnica);
        }
        public ActionResult PrintAll()
        {
            return new Rotativa.ActionAsPdf("GetAll");
        }
    }
}
