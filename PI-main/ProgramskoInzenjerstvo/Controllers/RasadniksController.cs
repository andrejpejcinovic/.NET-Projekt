using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProgramskoInzenjerstvo.Models;

namespace ProgramskoInzenjerstvo.Controllers
{
    public class RasadniksController : Controller
    {
        private Entities db = new Entities();

        // GET: Rasadniks
        public ActionResult Index()
        {
            var rasadniks = db.Rasadniks.Include(r => r.Bilje);
            return View(rasadniks.ToList());
        }
        [HttpGet]
        public async Task<ActionResult> Index( string sortingemp)
        {

            ViewData["Lokacija"] = string.IsNullOrEmpty(sortingemp) ? "Lokacija" : "";




            var empquery = from x in db.Rasadniks select x;

            switch (sortingemp)
            {
                case "Lokacija":
                    empquery = empquery.OrderBy(x => x.Lokacija);
                    break;
                


                default:
                    empquery = empquery.OrderByDescending(x => x.Lokacija);
                    break;
            }

            
            return View(await empquery.AsNoTracking().ToListAsync());
        }

        // GET: Rasadniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rasadnik rasadnik = db.Rasadniks.Find(id);
            if (rasadnik == null)
            {
                return HttpNotFound();
            }
            return View(rasadnik);
        }

        // GET: Rasadniks/Create
        public ActionResult Create()
        {
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod");
            return View();
        }

        // POST: Rasadniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRasadnik,Vrsta,Lokacija,IDBilje")] Rasadnik rasadnik)
        {
            if (ModelState.IsValid)
            {
                db.Rasadniks.Add(rasadnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", rasadnik.IDBilje);
            return View(rasadnik);
        }

        // GET: Rasadniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rasadnik rasadnik = db.Rasadniks.Find(id);
            if (rasadnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", rasadnik.IDBilje);
            return View(rasadnik);
        }

        // POST: Rasadniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRasadnik,Vrsta,Lokacija,IDBilje")] Rasadnik rasadnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rasadnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBilje = new SelectList(db.Biljes, "IDBilje", "Rod", rasadnik.IDBilje);
            return View(rasadnik);
        }

        // GET: Rasadniks/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Message = "Uspjesno izbrisano";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rasadnik rasadnik = db.Rasadniks.Find(id);
            if (rasadnik == null)
            {
                return HttpNotFound();
            }
            return View(rasadnik);
        }

        // POST: Rasadniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Message = "Uspjesno izbrisano";

            Rasadnik rasadnik = db.Rasadniks.Find(id);
            db.Rasadniks.Remove(rasadnik);
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
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var rasadnici = (from Rasadnik in db.Rasadniks
                          where Rasadnik.Vrsta.StartsWith(prefix)
                          select new
                          {
                              label = Rasadnik.Vrsta,
                              val = Rasadnik.IDRasadnik
                          }).ToList();
            return Json(rasadnici);
        }
    }
}
