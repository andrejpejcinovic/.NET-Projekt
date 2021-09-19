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
    public class PosiljkaKupovinasController : Controller
    {
        private Entities db = new Entities();

        // GET: PosiljkaKupovinas
        public ActionResult Index()
        {
            var posiljkaKupovinas = db.PosiljkaKupovinas.Include(p => p.Kupac).Include(p => p.PosiljkaStanje);
            return View(posiljkaKupovinas.ToList());
        }

        // GET: PosiljkaKupovinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaKupovina posiljkaKupovina = db.PosiljkaKupovinas.Find(id);
            if (posiljkaKupovina == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaKupovina);
        }

        // GET: PosiljkaKupovinas/Create
        public ActionResult Create()
        {
            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime");
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje");
            return View();
        }

        // POST: PosiljkaKupovinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPosiljkaKupovina,Datum,IDKupac,IDPosiljkaStanje")] PosiljkaKupovina posiljkaKupovina)
        {
            if (ModelState.IsValid)
            {
                db.PosiljkaKupovinas.Add(posiljkaKupovina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime", posiljkaKupovina.IDKupac);
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje", posiljkaKupovina.IDPosiljkaStanje);
            return View(posiljkaKupovina);
        }

        // GET: PosiljkaKupovinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaKupovina posiljkaKupovina = db.PosiljkaKupovinas.Find(id);
            if (posiljkaKupovina == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime", posiljkaKupovina.IDKupac);
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje", posiljkaKupovina.IDPosiljkaStanje);
            return View(posiljkaKupovina);
        }

        // POST: PosiljkaKupovinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPosiljkaKupovina,Datum,IDKupac,IDPosiljkaStanje")] PosiljkaKupovina posiljkaKupovina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posiljkaKupovina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime", posiljkaKupovina.IDKupac);
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje", posiljkaKupovina.IDPosiljkaStanje);
            return View(posiljkaKupovina);
        }

        // GET: PosiljkaKupovinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaKupovina posiljkaKupovina = db.PosiljkaKupovinas.Find(id);
            if (posiljkaKupovina == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaKupovina);
        }

        // POST: PosiljkaKupovinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PosiljkaKupovina posiljkaKupovina = db.PosiljkaKupovinas.Find(id);
            db.PosiljkaKupovinas.Remove(posiljkaKupovina);
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
