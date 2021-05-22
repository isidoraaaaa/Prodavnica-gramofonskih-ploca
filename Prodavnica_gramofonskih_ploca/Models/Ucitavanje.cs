using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Prodavnica_gramofonskih_ploca.Models
{
    public class Ucitavanje
    {
        public static Dictionary<string,Korisnik> OcitavanjeKorisnika(string putanja)
        {
            Dictionary<string,Korisnik> korisnici = new Dictionary<string, Korisnik>();
            putanja = HostingEnvironment.MapPath(putanja);
            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string linija = "";

            while ((linija = sr.ReadLine()) != null)
            {
                string[] delovi = linija.Split(';');
                Enum.TryParse(delovi[4], true, out Pol pol);
                Enum.TryParse(delovi[7], true, out TipKorisnika tip);

                DateTime.TryParse(delovi[6], out DateTime datum);
                Korisnik k = new Korisnik(delovi[0], delovi[1], delovi[2], delovi[3], pol ,delovi[5],datum,tip, Convert.ToBoolean(delovi[8]));
                korisnici.Add(k.KorisnickoIme,k);
            }

            sr.Close();
            stream.Close();
            return korisnici;
        }

        public static Dictionary<string, GramofonskaPloca> OcitavanjePloca(string putanja)
        {
            Dictionary<string, GramofonskaPloca> ploce = new Dictionary<string, GramofonskaPloca>();
            putanja = HostingEnvironment.MapPath(putanja);
            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string linija = "";

            while ((linija = sr.ReadLine()) != null)
            {
                string[] delovi = linija.Split(';');
                Enum.TryParse(delovi[2], true, out StanjePloce stanje);
                Enum.TryParse(delovi[3], true, out ZanrPloce zanr);
                


                GramofonskaPloca p = new GramofonskaPloca(delovi[0], delovi[1], stanje,zanr,delovi[4],Double.Parse(delovi[5]),Int32.Parse(delovi[6]),Convert.ToBoolean(delovi[7]), Convert.ToBoolean(delovi[8]),delovi[9]);
                ploce.Add(p.Naziv, p);
            }

            sr.Close();
            stream.Close();
            return ploce;
        }

        public static Dictionary<string, Radnja> OcitavanjeRadnji(string putanja)
        {
            Dictionary<string, Radnja> radnje = new Dictionary<string, Radnja>();
            putanja = HostingEnvironment.MapPath(putanja);
            FileStream stream = new FileStream(putanja, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            string linija = "";

            while ((linija = sr.ReadLine()) != null)
            {
                string[] delovi = linija.Split(';');
     
                Radnja r = new Radnja(delovi[0], delovi[1],Convert.ToBoolean(delovi[2]));
                radnje.Add(r.Naziv, r);
            }

            sr.Close();
            stream.Close();
            return radnje;
        }

        public static void UpisiKorisnika(Korisnik korisnik)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Korisnici.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine($"{korisnik.KorisnickoIme};{korisnik.Lozinka};{korisnik.Ime};{korisnik.Prezime};{korisnik.DatumRodjenja.ToString("dd/MM/yyyy")};{korisnik.PolKorisnika};{korisnik.Email};{korisnik.Uloga};{korisnik.Obrisan}");
                                                                 
                                                            
        }
       
        public static void UpisiPlocu(GramofonskaPloca ploca)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Ploce.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine($"{ploca.Naziv};{ploca.Izvodjac};{ploca.Stanje};{ploca.Zanr};{ploca.Opis};{ploca.Cena};{ploca.BrojKopijaNaStanju};{ploca.Obrisana};{ploca.NaProdaju};{ploca.NazivRadnje}");


        }

        public static void UpisiRadnju(Radnja radnja)
        {
            string path = HostingEnvironment.MapPath("~/App_Data/Radnje.txt");
            using (StreamWriter file = File.AppendText(path))
                file.WriteLine($"{radnja.Naziv};{radnja.Adresa};{radnja.Obrisan}");


        }
    }
}