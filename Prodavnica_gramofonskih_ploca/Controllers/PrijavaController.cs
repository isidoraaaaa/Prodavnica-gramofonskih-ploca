using Prodavnica_gramofonskih_ploca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavnica_gramofonskih_ploca.Controllers
{
    public class PrijavaController : Controller
    {
        // GET: Prijava
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prijavljivanje(string KorisnickoIme,string Lozinka)
        {
            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            bool greskaKorisnickoImeNeispravno = false;
            bool greskaNeodgovarajucaLozinka = false;
            bool greskaObrisanKorisnik = false;

            Korisnik korisnik = new Korisnik();

            if (!korisnici.ContainsKey(KorisnickoIme))
            {

                ViewBag.greskaKorisnickoImeNeispravno = "Uneli ste nepostojece korisnicko ime!";
                greskaKorisnickoImeNeispravno = true;
            }
            else
            {
                if (korisnici[KorisnickoIme].Lozinka != Lozinka)
                {
                    greskaNeodgovarajucaLozinka = true;
                    ViewBag.GreskaNeodgovarajucaLozinka = "Neispravna lozinka!";

                }
            }
            
            if(korisnici[KorisnickoIme].Obrisan==true)
            {
                ViewBag.GreskaObrisanKorisnik = "Korisnik je obrisan! Nemate mogucnost prijave!";
                greskaObrisanKorisnik = true;
            }

            if (greskaNeodgovarajucaLozinka == true || greskaKorisnickoImeNeispravno == true || greskaObrisanKorisnik ==true)
            {
                return View("~/Views/Prijava/Index.cshtml");
            }

            korisnik = korisnici[KorisnickoIme];
            Session["korisnik"] = korisnik;

            if(korisnik.Uloga.Equals(TipKorisnika.ADMINISTRATOR))
            {
                return RedirectToAction("Index","AdministratorskiPrikaz");
            }

           
                return RedirectToAction("Index", "KorisnickiPrikaz");
           

           
        }
    }
}