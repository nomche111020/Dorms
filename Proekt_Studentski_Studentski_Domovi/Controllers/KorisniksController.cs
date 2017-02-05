using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proekt_Studentski_Studentski_Domovi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proekt_Studentski_Studentski_Domovi.Controllers
{
    public class KorisniksController : Controller
    {
        private SD_BAZA_04_02_2017Entities db = new SD_BAZA_04_02_2017Entities();
        public ApplicationUser _userManager = new ApplicationUser();
        // GET: Korisniks
        public ActionResult Index(string SearchName)
        {
            //var korisniks = db.Korisniks.Include(k => k.Studentski_Dom).Include(k => k.Soba);

            var korisniks = from cr in db.Korisniks select cr;
            if (!String.IsNullOrEmpty(SearchName))
            {
                korisniks = korisniks.Where(c => c.Ime.Contains(SearchName));
            }

            return View(korisniks.ToList());
        }


        /*
         public ActionResult Index(string SearchName) 
         { 
         var cricketers = from cr in db.Cricketers select cr; 
         if (!String.IsNullOrEmpty(SearchName)) { 
         cricketers = cricketers.Where(c => c.Name.Contains(SearchName)); 
         }

            return View(cricketers); }
         */



        // GET: Korisniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisniks/Create
        public ActionResult Create()
        {
            ViewBag.Korisnik_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD");
            ViewBag.Korisnik_Soba = new SelectList(db.Sobas, "Id_Soba", "Id_Soba");
            return View();
        }

        // POST: Korisniks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Korisnik,Ime,Prezime,Adresa,Email,Godina_Na_Raganje,Pol,Godina_Na_Studii,Korisnik_SD,Korisnik_Soba")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisniks.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Korisnik_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD", korisnik.Korisnik_SD);
            ViewBag.Korisnik_Soba = new SelectList(db.Sobas, "Id_Soba", "Id_Soba", korisnik.Korisnik_Soba);




            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SD_BAZA_04_02_2017Entities()));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SD_BAZA_04_02_2017Entities()));

            var user = new ApplicationUser();
            user.UserName = korisnik.Ime;
            user.Email = korisnik.Email;

            string userPWD = "Test123!";

            var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin   
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "Student");

            }
            return View(korisnik);
        }

        // GET: Korisniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            ViewBag.Korisnik_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD", korisnik.Korisnik_SD);
            ViewBag.Korisnik_Soba = new SelectList(db.Sobas, "Id_Soba", "Id_Soba", korisnik.Korisnik_Soba);
            return View(korisnik);
        }

        // POST: Korisniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Korisnik,Ime,Prezime,Adresa,Email,Godina_Na_Raganje,Pol,Godina_Na_Studii,Korisnik_SD,Korisnik_Soba")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Korisnik_SD = new SelectList(db.Studentski_Dom, "SD_Id", "Ime_SD", korisnik.Korisnik_SD);
            ViewBag.Korisnik_Soba = new SelectList(db.Sobas, "Id_Soba", "Id_Soba", korisnik.Korisnik_Soba);
            return View(korisnik);
        }

        // GET: Korisniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisniks.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.Korisniks.Find(id);
            db.Korisniks.Remove(korisnik);
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
