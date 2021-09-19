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
using ProgramskoInzenjerstvo.ViewModels;
using PagedList.Mvc;
using PagedList;

namespace ProgramskoInzenjerstvo.Controllers
{
    public class BiljesController : Controller
    {
        private Entities db = new Entities();

        // GET: Biljes
        [HttpPost]


        public ActionResult Index()
        {


            return View(db.Biljes.ToList());
        }



        [HttpGet]
        public async Task<ActionResult> Index(string Empsearch, string sortingemp, int? i)
        {
            ViewData["GetVrsta"] = Empsearch;

            ViewData["Vrsta"] = string.IsNullOrEmpty(sortingemp) ? "Vrsta" : "";
            ViewData["Rod"] = string.IsNullOrEmpty(sortingemp) ? "Rod" : "";
            ViewData["Cijena"] = string.IsNullOrEmpty(sortingemp) ? "Cijena" : "";


            var empquery = from x in db.Biljes select x;

            switch (sortingemp)
            {
                case "Vrsta":
                    empquery = empquery.OrderBy(x => x.Vrsta);
                    break;
                case "Rod":
                    empquery = empquery.OrderBy(x => x.Rod);
                    break;
                case "cijena":
                    empquery = empquery.OrderBy(x => x.Cijena);
                    break;
                default:
                    empquery = empquery.OrderByDescending(x => x.Vrsta);
                    break;
            }

            if (!string.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.Vrsta.Contains(Empsearch) || x.Rod.Contains(Empsearch));
            }
            return View(await empquery.AsNoTracking().ToListAsync());
        }

        // GET: Biljes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilje bilje = db.Biljes.Find(id);
            if (bilje == null)
            {
                return HttpNotFound();
            }
            return View(bilje);
        }

        public ActionResult Putovnica(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilje bilje = db.Biljes.Find(id);
            if (bilje == null)
            {
                return HttpNotFound();
            }
            return View(bilje);
        }




        public ActionResult getUporaba(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BiljeUporaba biljeUporaba = db.BiljeUporabas.Find(id);
            if (biljeUporaba == null)
            {
                return HttpNotFound();
            }
            return View(biljeUporaba);
        }

        // GET: Biljes/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Uspjesno ste dodali novu biljku";

            return View();
        }

        // POST: Biljes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBilje,Cijena,Rod,Vrsta")] Bilje bilje)
        {
            ViewBag.Message = "Uspjesno ste dodali novu biljku";

            if (ModelState.IsValid)
            {
                try
                {
                    db.Biljes.Add(bilje);
                    db.SaveChanges();

                    return RedirectToAction("Details", "Biljes", new { id = bilje.IDBilje });
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Pogreska tijekom unosa" + e;

                }
            }
            else
            {
                ViewBag.Message = "Postoji pogreska u unosu";
            }

            return View(bilje);
        }

        

       


        // GET: Biljes/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Vrsta = new SelectList(db.Biljes, "Vrsta", "Vrsta");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Bilje bilje = db.Biljes.Find(id);
            if (bilje == null)
            {
                return HttpNotFound();
            }
            return View(bilje);
        }

        // POST: Biljes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBilje,Cijena,Rod,Vrsta")] Bilje bilje)
        {
            ViewBag.Message = "Uspjesno azurirano";

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Uspjesno azurirano!";

                db.Entry(bilje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilje);
        }

        // GET: Biljes/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilje bilje = db.Biljes.Find(id);
            if (bilje == null)
            {
                return HttpNotFound();
                ViewBag.Message = "Greska prilikom brisanja";
            }
            return View(bilje);
        }

        // POST: Biljes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                ViewBag.Message = "Greska prilikom brisanja";
            }
            else
            {
                try
                {
                    Bilje bilje = db.Biljes.Find(id);
                    db.Biljes.Remove(bilje);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    ViewBag.Message = "Uspjesno izbrisano";
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.ToString();
                    return RedirectToAction("Index");
                }

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
        public JsonResult GetSearchValue(string search)
        {
            Entities db = new Entities();
            List<Bilje> allsearch = db.Biljes.Where(x => x.Vrsta.Contains(search)).Select(x => new Bilje
            {
                IDBilje = x.IDBilje,
                Vrsta = x.Vrsta
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult PrintAll()
        {
            return new Rotativa.ActionAsPdf("Putovnica");
        }
    }
    
    
}