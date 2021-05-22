using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodavnica_gramofonskih_ploca.Models
{
    public class GramofonskaPloca
    {
        private string naziv;
        private string izvodjac;
        private StanjePloce stanje;
        private ZanrPloce zanr;
        private string opis;
        private double cena;
        private int brojKopijaNaStanju;
        private bool obrisana;
        private bool naProdaju;
        private string nazivRadnje;

        public GramofonskaPloca()
        {
            this.naziv = "";
            this.izvodjac = "";
            this.opis = "";
            this.cena = 0;
            this.brojKopijaNaStanju = 0;
        }

        public GramofonskaPloca(string naziv, string izvodjac, StanjePloce stanje, ZanrPloce zanr, string opis, double cena, int brojKopijaNaStanju,bool obrisana,bool naProdaju,string nazivRadnje)
        {
            this.naziv = naziv;
            this.izvodjac = izvodjac;
            this.stanje = stanje;
            this.zanr = zanr;
            this.opis = opis;
            this.cena = cena;
            this.brojKopijaNaStanju = brojKopijaNaStanju;
            this.obrisana = obrisana;
            this.naProdaju = naProdaju;
            this.nazivRadnje = nazivRadnje;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Izvodjac { get => izvodjac; set => izvodjac = value; }
        public StanjePloce Stanje { get => stanje; set => stanje = value; }
        public ZanrPloce Zanr { get => zanr; set => zanr = value; }
        public string Opis { get => opis; set => opis = value; }
        public double Cena { get => cena; set => cena = value; }
        public int BrojKopijaNaStanju { get => brojKopijaNaStanju; set => brojKopijaNaStanju = value; }
        public bool Obrisana { get => obrisana; set => obrisana = value; }
        public bool NaProdaju { get => naProdaju; set => naProdaju = value; }
        public string NazivRadnje { get => nazivRadnje; set => nazivRadnje = value; }
    }
}