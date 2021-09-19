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
    public class KupacsController : Controller
    {
        private Entities db = new Entities();

        // GET: Kupacs
        public ActionResult Index()
        {
            return View(db.Kupacs.ToList());
        }
        [HttpGet]
        public async Task<ActionResult> Index(string Empsearch, string sortingemp)
        {
            ViewData["GetPrezime"] = Empsearch;

            ViewData["Prezime"] = string.IsNullOrEmpty(sortingemp) ? "Prezime" : "";




            var empquery = from x in db.Kupacs select x;

            switch (sortingemp)
            {
                case "Prezime":
                    empquery = empquery.OrderBy(x => x.Prezime);
                    break;
                 default:
                    empquery = empquery.OrderByDescending(x => x.Prezime);
                    break;
            }

            if (!string.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.Prezime.Contains(Empsearch) || x.Ime.Contains(Empsearch));
            }
            return View(await empquery.AsNoTracking().ToListAsync());
        }

        // GET: Kupacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = db.Kupacs.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // GET: Kupacs/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Uspjesno dodano!";

            return View();
        }

        // POST: Kupacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKupac,Ime,Prezime,BrojTel,Email")] Kupac kupac)
        {
            ViewBag.Message = "Uspjesno dodano!";
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Uspjesno dodano!";

                db.Kupacs.Add(kupac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kupac);
        }

        // GET: Kupacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            ViewBag.Message = "Uspjesno azurirano";

            Kupac kupac = db.Kupacs.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // POST: Kupacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKupac,Ime,Prezime,BrojTel,Email")] Kupac kupac)
        {
            ViewBag.Message = "Uspjesno azurirano";

            if (ModelState.IsValid)
            {
                db.Entry(kupac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kupac);
        }

        // GET: Kupacs/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.Message = "Uspjesno izbrisano";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kupac kupac = db.Kupacs.Find(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // POST: Kupacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
                ViewBag.Message = "Uspjesno izbrisano";

            Kupac kupac = db.Kupacs.Find(id);
            db.Kupacs.Remove(kupac);
            db.SaveChanges();
                ViewBag.Message = "Uspjesno izbrisano";

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Message = "Greska prilikom brisanja " + e;
                return RedirectToAction("Index");
            }
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
