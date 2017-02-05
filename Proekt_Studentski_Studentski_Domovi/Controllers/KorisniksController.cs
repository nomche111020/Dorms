using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Proekt_Studentski_Studentski_Domovi.Models;

namespace Proekt_Studentski_Studentski_Domovi.Controllers
{
    public class KorisniksController : Controller
    {
        private SD_BAZA_04_02_2017Entities db = new SD_BAZA_04_02_2017Entities();

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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KorisnikViewModel korisnik)
        {
            Korisnik dbModel = new Korisnik();
            dbModel.Email = korisnik.Email;
            dbModel.Adresa = korisnik.Adresa;
            dbModel.Ime = korisnik.Ime;
            dbModel.Pol = korisnik.Pol;
            dbModel.Prezime = korisnik.Prezime;



            if (korisnik.Korisnik_Soba.HasValue) dbModel.ID_Soba = korisnik.Korisnik_Soba.Value;
            if (korisnik.Korisnik_SD.HasValue) dbModel.ID_Studentski_Dom = korisnik.Korisnik_SD.Value;
            if (korisnik.Godina_Na_Studii.HasValue) dbModel.Godina_Na_Studii = korisnik.Godina_Na_Studii.Value;
            if (korisnik.Godina_Na_Raganje.HasValue) dbModel.Godina_Na_Raganje = korisnik.Godina_Na_Raganje.Value;
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            role.Name = "Admin";
            roleManager.Create(role);

            ApplicationUser user = new ApplicationUser();

            user.Email = korisnik.Email;
            user.UserName = user.Email;

            var chkUser = userManager.Create(user, korisnik.Password);

            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Student");
            }

            if (ModelState.IsValid)
            {
                db.Korisniks.Add(dbModel);
                db.SaveChanges();
                return RedirectToAction("Index");
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

        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(UserViewModel plainUser)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            role.Name = "Admin";
            roleManager.Create(role);

            ApplicationUser user = new ApplicationUser();

            user.Email = plainUser.Email;
            user.UserName = user.Email;

            var chkUser = userManager.Create(user, plainUser.Password);

            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Student");

            }
            return RedirectToAction("Admin", "Home");
        }
    }

}
