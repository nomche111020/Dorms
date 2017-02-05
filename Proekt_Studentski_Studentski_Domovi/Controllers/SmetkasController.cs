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
    public class SmetkasController : Controller
    {
        private SD_BAZA_04_02_2017Entities db = new SD_BAZA_04_02_2017Entities();

        // GET: Smetkas
        public ActionResult Index()
        {
            var smetkas = db.Smetkas.Include(s => s.Korisnik).Include(s => s.Soba);
            return View(smetkas.ToList());
        }

        // GET: Smetkas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smetka smetka = db.Smetkas.Find(id);
            if (smetka == null)
            {
                return HttpNotFound();
            }
            return View(smetka);
        }

        // GET: Smetkas/Create
        public ActionResult Create()
        {
            ViewBag.Smetka_Student = new SelectList(db.Korisniks, "Id_Korisnik", "Ime");
            ViewBag.Smetka_Soba_Broj = new SelectList(db.Sobas, "Id_Soba", "Id_Soba");
            return View();
        }

        // POST: Smetkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Smetka,Smetka_Soba_Broj,Smetka_Student,Suma")] Smetka smetka)
        {
            if (ModelState.IsValid)
            {
                db.Smetkas.Add(smetka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Smetka_Student = new SelectList(db.Korisniks, "Id_Korisnik", "Ime", smetka.Smetka_Student);
            ViewBag.Smetka_Soba_Broj = new SelectList(db.Sobas, "Id_Soba", "Id_Soba", smetka.Smetka_Soba_Broj);
            return View(smetka);
        }

        // GET: Smetkas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smetka smetka = db.Smetkas.Find(id);
            if (smetka == null)
            {
                return HttpNotFound();
            }
            ViewBag.Smetka_Student = new SelectList(db.Korisniks, "Id_Korisnik", "Ime", smetka.Smetka_Student);
            ViewBag.Smetka_Soba_Broj = new SelectList(db.Sobas, "Id_Soba", "Id_Soba", smetka.Smetka_Soba_Broj);
            return View(smetka);
        }

        // POST: Smetkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Smetka,Smetka_Soba_Broj,Smetka_Student,Suma")] Smetka smetka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smetka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Smetka_Student = new SelectList(db.Korisniks, "Id_Korisnik", "Ime", smetka.Smetka_Student);
            ViewBag.Smetka_Soba_Broj = new SelectList(db.Sobas, "Id_Soba", "Id_Soba", smetka.Smetka_Soba_Broj);
            return View(smetka);
        }

        // GET: Smetkas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smetka smetka = db.Smetkas.Find(id);
            if (smetka == null)
            {
                return HttpNotFound();
            }
            return View(smetka);
        }

        // POST: Smetkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smetka smetka = db.Smetkas.Find(id);
            db.Smetkas.Remove(smetka);
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
