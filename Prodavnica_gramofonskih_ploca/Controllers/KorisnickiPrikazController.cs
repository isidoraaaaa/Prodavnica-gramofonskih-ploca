using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prodavnica_gramofonskih_ploca.Controllers
{
    public class KorisnickiPrikazController : Controller
    {
        // GET: KorisnickiPrikaz
        public ActionResult Index()
        {
            return View();
        }
    }
}