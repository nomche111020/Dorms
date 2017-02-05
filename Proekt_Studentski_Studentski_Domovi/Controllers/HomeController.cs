using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proekt_Studentski_Studentski_Domovi.Models;

namespace Proekt_Studentski_Studentski_Domovi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.Message = "Админ страна";
            return View();
        }

        public ActionResult Student()
        {
            var email = User.Identity.GetUserName();
            if (User.Identity.GetUserName() != null || User.Identity.GetUserName() != "")
            {
                Korisnik kor = new Korisnik();
                using (var db = new SD_BAZA_04_02_2017Entities())
                {
                    kor = db.Korisniks.First(korisnik => korisnik.Email == email);
                }
                return View(kor);
            }
            return RedirectToAction("Index");
        }
    }
}