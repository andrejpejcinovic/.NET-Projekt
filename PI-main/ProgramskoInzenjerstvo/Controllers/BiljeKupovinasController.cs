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
    public class BiljeKupovinasController : Controller
    {
        private Entities db = new Entities();

        // GET: BiljeKupovinas
        public ActionResult Index()
        {
            var biljeKupovinas = db.BiljeKupovinas.Include(b => b.Bilje).Include(b => b.MjernaJedinica).Include(b => b.PosiljkaKupovina);
            return View(biljeKupovinas.ToList());
        }


        // GET: BiljeKupovinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeKupovina biljeKupovina = db.BiljeKupovinas.Find(id);
            if (biljeKupovina == null)
            {
                return HttpNotFound();
            }
            return View(biljeKupovina);
        }

        // GET: BiljeKupovinas/Create
        public ActionResult Create()
        {
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Vrsta");
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1");
            ViewBag.IDPosiljkaKupovina = new SelectList(db.PosiljkaKupovinas, "IDPosiljkaKupovina", "IDPosiljkaKupovina");
            return View();
        }

        // POST: BiljeKupovinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBiljeKupovina,Kolicina,CijenaKupovno,IDMjernaJedinica,IDPosiljkaKupovina,IDBilje")] BiljeKupovina biljeKupovina)
        {
            if (ModelState.IsValid)
            {
                db.BiljeKupovinas.Add(biljeKupovina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeKupovina.IDBilje);
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1", biljeKupovina.IDMjernaJedinica);
            ViewBag.IDPosiljkaKupovina = new SelectList(db.PosiljkaKupovinas, "IDPosiljkaKupovina", "IDPosiljkaKupovina", biljeKupovina.IDPosiljkaKupovina);
            return View(biljeKupovina);
        }

        // GET: BiljeKupovinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeKupovina biljeKupovina = db.BiljeKupovinas.Find(id);
            if (biljeKupovina == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeKupovina.IDBilje);
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1", biljeKupovina.IDMjernaJedinica);
            ViewBag.IDPosiljkaKupovina = new SelectList(db.PosiljkaKupovinas, "IDPosiljkaKupovina", "IDPosiljkaKupovina", biljeKupovina.IDPosiljkaKupovina);
            return View(biljeKupovina);
        }

        // POST: BiljeKupovinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBiljeKupovina,Kolicina,CijenaKupovno,IDMjernaJedinica,IDPosiljkaKupovina,IDBilje")] BiljeKupovina biljeKupovina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biljeKupovina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeKupovina.IDBilje);
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1", biljeKupovina.IDMjernaJedinica);
            ViewBag.IDPosiljkaKupovina = new SelectList(db.PosiljkaKupovinas, "IDPosiljkaKupovina", "IDPosiljkaKupovina", biljeKupovina.IDPosiljkaKupovina);
            return View(biljeKupovina);
        }

        // GET: BiljeKupovinas/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Message = "Uspjesno izbrisano";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeKupovina biljeKupovina = db.BiljeKupovinas.Find(id);
            if (biljeKupovina == null)
            {
                return HttpNotFound();
            }
            return View(biljeKupovina);
        }

        // POST: BiljeKupovinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Message = "Uspjesno izbrisano";
            BiljeKupovina biljeKupovina = db.BiljeKupovinas.Find(id);
            db.BiljeKupovinas.Remove(biljeKupovina);
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