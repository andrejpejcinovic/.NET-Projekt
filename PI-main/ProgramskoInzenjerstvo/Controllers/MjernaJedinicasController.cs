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
    public class MjernaJedinicasController : Controller
    {
        private Entities db = new Entities();

        // GET: MjernaJedinicas
        public ActionResult Index()
        {
            return View(db.MjernaJedinicas.ToList());
        }

        // GET: MjernaJedinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MjernaJedinica mjernaJedinica = db.MjernaJedinicas.Find(id);
            if (mjernaJedinica == null)
            {
                return HttpNotFound();
            }
            return View(mjernaJedinica);
        }

        // GET: MjernaJedinicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MjernaJedinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMjernaJedinica,MjernaJedinica1")] MjernaJedinica mjernaJedinica)
        {
            if (ModelState.IsValid)
            {
                db.MjernaJedinicas.Add(mjernaJedinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mjernaJedinica);
        }

        // GET: MjernaJedinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MjernaJedinica mjernaJedinica = db.MjernaJedinicas.Find(id);
            if (mjernaJedinica == null)
            {
                return HttpNotFound();
            }
            return View(mjernaJedinica);
        }

        // POST: MjernaJedinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMjernaJedinica,MjernaJedinica1")] MjernaJedinica mjernaJedinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mjernaJedinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mjernaJedinica);
        }

        // GET: MjernaJedinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MjernaJedinica mjernaJedinica = db.MjernaJedinicas.Find(id);
            if (mjernaJedinica == null)
            {
                return HttpNotFound();
            }
            return View(mjernaJedinica);
        }

        // POST: MjernaJedinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MjernaJedinica mjernaJedinica = db.MjernaJedinicas.Find(id);
            db.MjernaJedinicas.Remove(mjernaJedinica);
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
