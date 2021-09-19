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
    public class BiljeNarudzbasController : Controller
    {
        private Entities db = new Entities();

        // GET: BiljeNarudzbas
        public ActionResult Index()
        {
            var biljeNarudzbas = db.BiljeNarudzbas.Include(b => b.Bilje).Include(b => b.MjernaJedinica).Include(b => b.PosiljkaNarudzba);
            return View(biljeNarudzbas.ToList());
        }

        // GET: BiljeNarudzbas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeNarudzba biljeNarudzba = db.BiljeNarudzbas.Find(id);
            if (biljeNarudzba == null)
            {
                return HttpNotFound();
            }
            return View(biljeNarudzba);
        }

        // GET: BiljeNarudzbas/Create
        public ActionResult Create()
        {
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod");
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1");
            ViewBag.IDPosiljkaNarudzba = new SelectList(db.PosiljkaNarudzbas, "IDPosiljkaNarudzba", "IDPosiljkaNarudzba");
            return View();
        }

        // POST: BiljeNarudzbas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBiljeNarudzba,Kolicina,CijenaDogovoreno,IDMjernaJedinica,IDPosiljkaNarudzba,IDBilje")] BiljeNarudzba biljeNarudzba)
        {
            if (ModelState.IsValid)
            {
                db.BiljeNarudzbas.Add(biljeNarudzba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeNarudzba.IDBilje);
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1", biljeNarudzba.IDMjernaJedinica);
            ViewBag.IDPosiljkaNarudzba = new SelectList(db.PosiljkaNarudzbas, "IDPosiljkaNarudzba", "IDPosiljkaNarudzba", biljeNarudzba.IDPosiljkaNarudzba);
            return View(biljeNarudzba);
        }

        // GET: BiljeNarudzbas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeNarudzba biljeNarudzba = db.BiljeNarudzbas.Find(id);
            if (biljeNarudzba == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeNarudzba.IDBilje);
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1", biljeNarudzba.IDMjernaJedinica);
            ViewBag.IDPosiljkaNarudzba = new SelectList(db.PosiljkaNarudzbas, "IDPosiljkaNarudzba", "IDPosiljkaNarudzba", biljeNarudzba.IDPosiljkaNarudzba);
            return View(biljeNarudzba);
        }

        // POST: BiljeNarudzbas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBiljeNarudzba,Kolicina,CijenaDogovoreno,IDMjernaJedinica,IDPosiljkaNarudzba,IDBilje")] BiljeNarudzba biljeNarudzba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biljeNarudzba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", biljeNarudzba.IDBilje);
            ViewBag.IDMjernaJedinica = new SelectList(db.MjernaJedinicas, "IDMjernaJedinica", "MjernaJedinica1", biljeNarudzba.IDMjernaJedinica);
            ViewBag.IDPosiljkaNarudzba = new SelectList(db.PosiljkaNarudzbas, "IDPosiljkaNarudzba", "IDPosiljkaNarudzba", biljeNarudzba.IDPosiljkaNarudzba);
            return View(biljeNarudzba);
        }

        // GET: BiljeNarudzbas/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Message = "Uspjesno izbrisano";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeNarudzba biljeNarudzba = db.BiljeNarudzbas.Find(id);
            if (biljeNarudzba == null)
            {
                return HttpNotFound();
            }
            return View(biljeNarudzba);
        }

        // POST: BiljeNarudzbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Message = "Uspjesno izbrisano";

            BiljeNarudzba biljeNarudzba = db.BiljeNarudzbas.Find(id);
            db.BiljeNarudzbas.Remove(biljeNarudzba);
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
