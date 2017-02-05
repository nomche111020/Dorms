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
    public class Studentski_DomController : Controller
    {
        private SD_BAZA_04_02_2017Entities db = new SD_BAZA_04_02_2017Entities();

        // GET: Studentski_Dom
        public ActionResult Index()
        {
            return View(db.Studentski_Dom.ToList());
        }

        // GET: Studentski_Dom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentski_Dom studentski_Dom = db.Studentski_Dom.Find(id);
            if (studentski_Dom == null)
            {
                return HttpNotFound();
            }
            return View(studentski_Dom);
        }

        // GET: Studentski_Dom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studentski_Dom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SD_Id,Ime_SD,Adresa,Broj_Spratovi,Broj_Sobi,Opis")] Studentski_Dom studentski_Dom)
        {
            if (ModelState.IsValid)
            {
                db.Studentski_Dom.Add(studentski_Dom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentski_Dom);
        }

        // GET: Studentski_Dom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentski_Dom studentski_Dom = db.Studentski_Dom.Find(id);
            if (studentski_Dom == null)
            {
                return HttpNotFound();
            }
            return View(studentski_Dom);
        }

        // POST: Studentski_Dom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SD_Id,Ime_SD,Adresa,Broj_Spratovi,Broj_Sobi,Opis")] Studentski_Dom studentski_Dom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentski_Dom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentski_Dom);
        }

        // GET: Studentski_Dom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentski_Dom studentski_Dom = db.Studentski_Dom.Find(id);
            if (studentski_Dom == null)
            {
                return HttpNotFound();
            }
            return View(studentski_Dom);
        }

        // POST: Studentski_Dom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studentski_Dom studentski_Dom = db.Studentski_Dom.Find(id);
            db.Studentski_Dom.Remove(studentski_Dom);
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
