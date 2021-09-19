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
    public class PosiljkaStanjesController : Controller
    {
        private Entities db = new Entities();

        // GET: PosiljkaStanjes
        public ActionResult Index()
        {
            return View(db.PosiljkaStanjes.ToList());
        }

        // GET: PosiljkaStanjes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaStanje posiljkaStanje = db.PosiljkaStanjes.Find(id);
            if (posiljkaStanje == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaStanje);
        }

        // GET: PosiljkaStanjes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PosiljkaStanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPosiljkaStanje,Stanje")] PosiljkaStanje posiljkaStanje)
        {
            if (ModelState.IsValid)
            {
                db.PosiljkaStanjes.Add(posiljkaStanje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posiljkaStanje);
        }

        // GET: PosiljkaStanjes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaStanje posiljkaStanje = db.PosiljkaStanjes.Find(id);
            if (posiljkaStanje == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaStanje);
        }

        // POST: PosiljkaStanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPosiljkaStanje,Stanje")] PosiljkaStanje posiljkaStanje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posiljkaStanje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posiljkaStanje);
        }

        // GET: PosiljkaStanjes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PosiljkaStanje posiljkaStanje = db.PosiljkaStanjes.Find(id);
            if (posiljkaStanje == null)
            {
                return HttpNotFound();
            }
            return View(posiljkaStanje);
        }

        // POST: PosiljkaStanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                PosiljkaStanje posiljkaStanje = db.PosiljkaStanjes.Find(id);
            db.PosiljkaStanjes.Remove(posiljkaStanje);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                 ViewBag.Message = "Pogreska tijekom unosa" + e;
                return RedirectToAction("Delete");
            }
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
