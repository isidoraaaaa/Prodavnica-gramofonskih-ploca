using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodavnica_gramofonskih_ploca.Models
{
    public class Kupovina
    {
        private Korisnik kupac;
        private List<GramofonskaPloca> izabranePloce;
        private DateTime datumKupovine;
        private double ukupnoNaplaceno;

        public Kupovina(Korisnik kupac, DateTime datumKupovine, double ukupnoNaplaceno)
        {
            this.kupac = kupac;
            this.datumKupovine = datumKupovine;
            this.ukupnoNaplaceno = ukupnoNaplaceno;
        }

        public Korisnik Kupac { get => kupac; set => kupac = value; }
        public List<GramofonskaPloca> IzabranePloce { get => izabranePloce; set => izabranePloce = value; }
        public DateTime DatumKupovine { get => datumKupovine; set => datumKupovine = value; }
        public double UkupnoNaplaceno { get => ukupnoNaplaceno; set => ukupnoNaplaceno = value; }
    }
}