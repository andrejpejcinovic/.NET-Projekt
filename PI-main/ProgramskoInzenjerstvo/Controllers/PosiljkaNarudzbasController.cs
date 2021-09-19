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
    public class PosiljkaNarudzbasController : Controller
    {
        private Entities db = new Entities();

        // GET: PosiljkaNarudzbas
        public ActionResult Index()
        {
            var posiljkaNarudzbas = db.PosiljkaNarudzbas.Include(p => p.Kupac).Include(p => p.PosiljkaStanje);
            return View(posiljkaNarudzbas.ToList());
        }

        // GET: PosiljkaNarudzbas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaNarudzba posiljkaNarudzba = db.PosiljkaNarudzbas.Find(id);
            if (posiljkaNarudzba == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaNarudzba);
        }

        // GET: PosiljkaNarudzbas/Create
        public ActionResult Create()
        {
            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime");
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje");
            return View();
        }

        // POST: PosiljkaNarudzbas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPosiljkaNarudzba,Datum,IDKupac,IDPosiljkaStanje")] PosiljkaNarudzba posiljkaNarudzba)
        {
            if (ModelState.IsValid)
            {
                db.PosiljkaNarudzbas.Add(posiljkaNarudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime", posiljkaNarudzba.IDKupac);
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje", posiljkaNarudzba.IDPosiljkaStanje);
            return View(posiljkaNarudzba);
        }

        // GET: PosiljkaNarudzbas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaNarudzba posiljkaNarudzba = db.PosiljkaNarudzbas.Find(id);
            if (posiljkaNarudzba == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime", posiljkaNarudzba.IDKupac);
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje", posiljkaNarudzba.IDPosiljkaStanje);
            return View(posiljkaNarudzba);
        }

        // POST: PosiljkaNarudzbas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPosiljkaNarudzba,Datum,IDKupac,IDPosiljkaStanje")] PosiljkaNarudzba posiljkaNarudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posiljkaNarudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKupac = new SelectList(db.Kupacs, "IDKupac", "Ime", posiljkaNarudzba.IDKupac);
            ViewBag.IDPosiljkaStanje = new SelectList(db.PosiljkaStanjes, "IDPosiljkaStanje", "Stanje", posiljkaNarudzba.IDPosiljkaStanje);
            return View(posiljkaNarudzba);
        }

        // GET: PosiljkaNarudzbas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaNarudzba posiljkaNarudzba = db.PosiljkaNarudzbas.Find(id);
            if (posiljkaNarudzba == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaNarudzba);
        }

        // POST: PosiljkaNarudzbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PosiljkaNarudzba posiljkaNarudzba = db.PosiljkaNarudzbas.Find(id);
            db.PosiljkaNarudzbas.Remove(posiljkaNarudzba);
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
