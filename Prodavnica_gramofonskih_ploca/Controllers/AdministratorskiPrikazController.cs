using Prodavnica_gramofonskih_ploca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavnica_gramofonskih_ploca.Controllers
{
    public class AdministratorskiPrikazController : Controller
    {
        string nazivPloce = "";
        // GET: AdministratorskiPrikaz
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sortiraj(string kriterijum, string nacin)
        {
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];
            Dictionary<string, GramofonskaPloca> novePloce = new Dictionary<string, GramofonskaPloca>();



            if (kriterijum.Equals("Nazivu") && nacin.Equals("Rastuce"))
            {
                foreach (var ploca in ploce.OrderBy(key => key.Value.Naziv))
                    novePloce.Add(ploca.Value.Naziv, ploca.Value);
            }

            if (kriterijum.Equals("Autoru") && nacin.Equals("Rastuce"))
            {
                foreach (var ploca in ploce.OrderBy(key => key.Value.Izvodjac))
                    novePloce.Add(ploca.Value.Naziv, ploca.Value);
            }

            if (kriterijum.Equals("Ceni") && nacin.Equals("Rastuce"))
            {
                foreach (var ploca in ploce.OrderBy(key => key.Value.Cena))
                    novePloce.Add(ploca.Value.Naziv, ploca.Value);
            }


            if (kriterijum.Equals("Nazivu") && nacin.Equals("Opadajuce"))
            {
                foreach (var ploca in ploce.OrderByDescending(key => key.Value.Naziv))
                    novePloce.Add(ploca.Value.Naziv, ploca.Value);
            }

            if (kriterijum.Equals("Autoru") && nacin.Equals("Opadajuce"))
            {
                foreach (var ploca in ploce.OrderByDescending(key => key.Value.Izvodjac))
                    novePloce.Add(ploca.Value.Naziv, ploca.Value);
            }

            if (kriterijum.Equals("Ceni") && nacin.Equals("Opadajuce"))
            {
                foreach (var ploca in ploce.OrderByDescending(key => key.Value.Cena))
                    novePloce.Add(ploca.Value.Naziv, ploca.Value);
            }

            HttpContext.Application["ploce"] = novePloce;

            return View("~/Views/AdministratorskiPrikaz/Index.cshtml");
        }

        public ActionResult PretraziPoAutoruIliNazivu(string pretragaPoNazivuIliAutoru, string naziviliautor)
        {
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];
            Dictionary<string, GramofonskaPloca> novePloce = new Dictionary<string, GramofonskaPloca>();

            if (pretragaPoNazivuIliAutoru.Equals("Nazivu"))
            {
                foreach (var ploca in ploce.Values)
                {
                    if (ploca.Naziv.Equals(naziviliautor))
                    {
                        novePloce.Add(ploca.Naziv, ploca);
                    }
                }
            }

            if (pretragaPoNazivuIliAutoru.Equals("Autoru"))
            {
                foreach (var ploca in ploce.Values)
                {
                    if (ploca.Izvodjac.Equals(naziviliautor))
                    {
                        novePloce.Add(ploca.Naziv, ploca);
                    }
                }
            }

            HttpContext.Application["ploce"] = novePloce;

             return View("~/Views/AdministratorskiPrikaz/Index.cshtml"); ;
        }

        [HttpPost]

        public ActionResult PretraziPoCeni(double odCene, double doCene)
        {
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];
            Dictionary<string, GramofonskaPloca> novePloce = new Dictionary<string, GramofonskaPloca>();

            //double cena1 = double.Parse(odCene);
            //double cena2 = double.Parse(doCene);

            foreach (var ploca in ploce.Values)
            {
                if (ploca.Cena <= doCene && ploca.Cena >= odCene)
                    novePloce.Add(ploca.Naziv, ploca);
            }

            HttpContext.Application["ploce"] = novePloce;

            return View("Index");
        }

        [HttpPost]
        public ActionResult BrisanjeKorisnika(string korisnickoIme)
        {

            Dictionary<string, Korisnik> korisnici = (Dictionary<string, Korisnik>)HttpContext.Application["korisnici"];
            korisnici[korisnickoIme].Obrisan = true;
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult DodavanjeNoveRadnje()
        {

            return View();

        }

        [HttpPost]

        public ActionResult DodataRadnja(string naziv, string adresa)
        {
            Dictionary<string, Radnja> radnje = (Dictionary<string, Radnja>)HttpContext.Application["radnje"];

            bool greskaNazivDuzina =false;
            bool greskaNazivPostojeci = false;

            Radnja r = new Radnja(naziv, adresa,false);

            if (naziv.Length < 1)
            {
                ViewBag.GreskaNazivDuzina = "Naziv ulice mora imati minimalno 1 karakter";
                greskaNazivDuzina = true;
            }

            if (radnje.ContainsKey(naziv))
            {
                greskaNazivPostojeci = true;
                ViewBag.GreskaNazivPostojeci = "Dati naziv vec postoji! Naziv mora biti jedinstven";
            }

            if (greskaNazivDuzina == true || greskaNazivPostojeci == true)
            {
                return View("DodavanjeNoveRadnje");
            }

            

            radnje.Add(r.Naziv, r);
            Ucitavanje.UpisiRadnju(r);
            HttpContext.Application["radnje"] = radnje;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult BrisanjeRadnje(string naziv)
        {

            Dictionary<string, Radnja> radnje = (Dictionary<string, Radnja>)HttpContext.Application["radnje"];
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];
            radnje[naziv].Obrisan = true;
           // radnje[naziv].Ploce = new Dictionary<string, GramofonskaPloca>();
            foreach(var p in ploce.Values)
            {
                if (p.NazivRadnje == naziv)
                    ploce[p.Naziv].Obrisana = true;
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult DodavanjeNovePloce()
        {
            return View();
        }
      

       

        [HttpPost]
        public ActionResult PlocaDodataURadnju(GramofonskaPloca p)
        {
            Dictionary<string, Radnja> radnje = (Dictionary<string, Radnja>)HttpContext.Application["radnje"];
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];


            bool greskaIspravanNaziv = false;
            bool greksaCena = false;
            bool greskeBrojKopija = false;
            bool greskaNazivPostojeciURadnji = false;
            bool greskaNazivPostojeciURecniku = false;


            Radnja r = new Radnja();

            r = radnje[p.NazivRadnje];

            if(ploce.ContainsKey(p.Naziv))

            {
                greskaNazivPostojeciURecniku = true;
                ViewBag.GreskaPostojeciNazivURecniku = "Naziv vec postoji u recniku";
            }

            if(r.Ploce.ContainsKey(p.Naziv))
            {
                greskaNazivPostojeciURadnji = true;
                ViewBag.GreskaNazivPostojeci = "Ploca sa datim nazivom vec postoji u radnji!";
            }

            if (p.Naziv.Length < 1)
            {
                greskaIspravanNaziv = true;
                ViewBag.GreskaIspravanNaziv = "Naziv mora imati jedan ili vise karaktera!";
            }

            if (p.Cena > 30000 || p.Cena < 0)
            {
                greksaCena = true;
                ViewBag.GreskaCena = "Cena mora biti u opsegu od 0 do 30 000";
            }

            if (p.BrojKopijaNaStanju > 1000 || p.BrojKopijaNaStanju < 0)
            {
                greskeBrojKopija = true;
                ViewBag.GreskaBrojKopija = "Broj kopija mora biti u opsegu od 0 do 1000";
            }

            if (greskeBrojKopija == true || greskaIspravanNaziv == true || greksaCena == true || greskaNazivPostojeciURecniku==true || greskaNazivPostojeciURadnji==true)
            {
                return View("DodavanjeNovePloce");
            }

            r.Ploce.Add(p.Naziv,p);

            ploce.Add(p.Naziv, p);
            Ucitavanje.UpisiPlocu(p);
            HttpContext.Application["radnje"]=radnje;
            HttpContext.Application["ploce"] = ploce;
            return RedirectToAction("Index");

        }

        [HttpPost]

        public ActionResult IzmenaPloce()
        {
            return View();
        }

        [HttpPost]

        public ActionResult IzmenjenaPloca(GramofonskaPloca p)
        {
             bool pronadjena = false;
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];
            GramofonskaPloca p1 = new GramofonskaPloca();
            foreach(var ploca in ploce.Values)
            {
                if (ploca.Naziv.Equals(p.Naziv))
                {
                    p1 = ploca;
                    pronadjena = true;

                }
             
                   
               
            }
            if(pronadjena==false)
            {
                ViewBag.NijePronadjena = "Ploca nije pronadjena";
                return View("IzmenaPloce"); ;
            }



            ploce[p1.Naziv] = p;
            

            return RedirectToAction("Index");
        }
    }
}