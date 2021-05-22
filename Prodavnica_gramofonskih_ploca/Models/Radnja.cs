using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodavnica_gramofonskih_ploca.Models
{
    public class Radnja
    {
        private string naziv;
        private string adresa;
        private bool obrisan;
      
        private Dictionary<string, GramofonskaPloca> ploce = new Dictionary<string, GramofonskaPloca>();

        public Radnja()
        {
            this.naziv = string.Empty;
            this.adresa = string.Empty;
        }
        public Radnja(string naziv, string adresa, bool obrisana)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Obrisan = obrisana;

        }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public Dictionary<string, GramofonskaPloca> Ploce { get => ploce; set => ploce = value; }
        public bool Obrisan { get => obrisan; set => obrisan = value; }
    }
}