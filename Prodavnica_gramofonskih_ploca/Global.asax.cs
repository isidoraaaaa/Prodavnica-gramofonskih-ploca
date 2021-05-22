using Prodavnica_gramofonskih_ploca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Prodavnica_gramofonskih_ploca
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Dictionary<string,Korisnik> korisnici = Ucitavanje.OcitavanjeKorisnika("~/App_Data/Korisnici.txt");

            HttpContext.Current.Application["korisnici"] = korisnici;

            Dictionary<string, GramofonskaPloca> ploce = Ucitavanje.OcitavanjePloca("~/App_Data/Ploce.txt");

            HttpContext.Current.Application["ploce"] = ploce;

            Dictionary<string, Radnja> radnje = Ucitavanje.OcitavanjeRadnji("~/App_Data/Radnje.txt");

            HttpContext.Current.Application["radnje"] = radnje;

        }
    }
}
