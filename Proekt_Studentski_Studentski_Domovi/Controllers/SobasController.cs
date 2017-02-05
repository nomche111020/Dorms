using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proekt_Studentski_Studentski_Domovi.Models;

namespace Proekt_Studentski_Studentski_Domovi.Controllers
{
    public class SobasController : Controller
    {
        private SD_BAZA_04_02_2017Entities db = new SD_BAZA_04_02_2017Entities();

        // GET: Sobas
        public ActionResult Index()
        {
            var sobas = db.Sobas.Include(s => s.Studentski_Dom);
            return View(sobas.ToList());
        }

        // GET: Sobas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return HttpNotFound();
            }
            return View(soba);
        }

        // GET: Sobas/Create
        public ActionResult Create()
        {
            ViewBag.Naziv_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD");
            return View();
        }

        // POST: Sobas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Soba,Naziv_SD,Sprat,Broj_Soba,Kapacitet,Cena_Po_Lice,Dostapnost")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                db.Sobas.Add(soba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Naziv_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD", soba.Naziv_SD);
            return View(soba);
        }

        // GET: Sobas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return HttpNotFound();
            }
            ViewBag.Naziv_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD", soba.Naziv_SD);
            return View(soba);
        }

        // POST: Sobas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Soba,Naziv_SD,Sprat,Broj_Soba,Kapacitet,Cena_Po_Lice,Dostapnost")] Soba soba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Naziv_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD", soba.Naziv_SD);
            return View(soba);
        }

        // GET: Sobas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soba soba = db.Sobas.Find(id);
            if (soba == null)
            {
                return HttpNotFound();
            }
            return View(soba);
        }

        // POST: Sobas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soba soba = db.Sobas.Find(id);
            db.Sobas.Remove(soba);
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
