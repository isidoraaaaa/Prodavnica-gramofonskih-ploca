using Prodavnica_gramofonskih_ploca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Prodavnica_gramofonskih_ploca.Controllers
{
    public class RegistracijaController : Controller
    {
        // GET: Registracija
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registruj(Korisnik korisnik)
        {
          Dictionary<string,Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];

            korisnik.Uloga = TipKorisnika.KUPAC;

            bool greskaKorisnickoImeDuzina = false;
            bool greskaKorisnickoImeJedinstveno = false;
            bool greskaLozinkaDuzina = false;
            bool greskaLozinkaKarakteri = false;

            Regex ispravnaSifra = new Regex("^[a-zA-Z0-9 ]*$");


            if (korisnik.KorisnickoIme.Length<3)
            {
                ViewBag.GreskaKorisnickoImeDuzina = "Korisnicko ime mora sadrzati minimum 3 karaktera!";
                greskaKorisnickoImeDuzina = true;
            }
            
            if(korisnici.ContainsKey(korisnik.KorisnickoIme))
            {
                ViewBag.GreskaKorisnickoImeJedinstveno = "Korisnicko ime vec postoji!";
                greskaKorisnickoImeJedinstveno = true;
            }
            
            if(korisnik.Lozinka.Length<8)
            {
                ViewBag.GreskaLozinkaDuzina = "Lozinka mora imati minimum 8 karaktera!";
                greskaLozinkaDuzina = true;
            }

            if(ispravnaSifra.IsMatch(korisnik.Lozinka)==false)
            {
                greskaLozinkaKarakteri = true;
                ViewBag.greskaLozinkaKarakteri = "Lozinka ne sme sadrzati karaktere koji nisu slova i brojevi!";
            }

            if (greskaKorisnickoImeDuzina == true || greskaLozinkaDuzina==true || greskaKorisnickoImeJedinstveno==true || greskaLozinkaKarakteri==true)
            {
                return View("~/Views/Registracija/Index.cshtml");
            }

            korisnici.Add(korisnik.KorisnickoIme, korisnik);
            Ucitavanje.UpisiKorisnika(korisnik);
            HttpContext.Application["korisnici"] = korisnici;

            return View("~/Views/Prijava/Index.cshtml");

          

        }
    }
}