using Prodavnica_gramofonskih_ploca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavnica_gramofonskih_ploca.Controllers
{
    public class PrikazPlocaController : Controller
    {
        // GET: PrikazPloca
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

            return View("~/Views/PrikazPloca/Index.cshtml");
        }

        public ActionResult PretraziPoAutoruIliNazivu(string pretragaPoNazivuIliAutoru,string naziviliautor)
        {
            Dictionary<string, GramofonskaPloca> ploce = (Dictionary<string, GramofonskaPloca>)HttpContext.Application["ploce"];
            Dictionary<string, GramofonskaPloca> novePloce = new Dictionary<string, GramofonskaPloca>();

            if (pretragaPoNazivuIliAutoru.Equals("Nazivu"))
            {
                foreach(var ploca in ploce.Values)
                {
                    if(ploca.Naziv.Equals(naziviliautor))
                    {
                        novePloce.Add(ploca.Naziv,ploca);
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

            return View("~/Views/PrikazPloca/Index.cshtml");
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

            return View("~/Views/PrikazPloca/Index.cshtml");
        }
    }
}