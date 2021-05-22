using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prodavnica_gramofonskih_ploca.Models
{
    public class Korisnik
    {
        private string korisnickoIme;
        private string lozinka;
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private Pol polKorisnika;
        private string email;
        private TipKorisnika uloga;
        private bool obrisan;

        public Korisnik()
        {
            this.korisnickoIme = string.Empty;
            this.lozinka = string.Empty;
            this.ime = string.Empty;
            this.prezime = string.Empty;
            this.email = string.Empty;
            
        }
        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, Pol polKorisnika, string email, DateTime datumRodjenja,TipKorisnika uloga, bool obrisan)
        {
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.polKorisnika = polKorisnika;
            this.email = email;
            this.uloga = uloga;
            this.obrisan = obrisan;
        }

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public Pol PolKorisnika { get => polKorisnika; set => polKorisnika = value; }
        public string Email { get => email; set => email = value; }
        public TipKorisnika Uloga { get => uloga; set => uloga = value; }
        public bool Obrisan { get => obrisan; set => obrisan = value; }
    }
}