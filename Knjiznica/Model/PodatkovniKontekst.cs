using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Knjiznica.Model
{
    public class PodatkovniKontekst
    {
        //Kolekcije
        public List<Ucenik> _ucenici;
     
        public List<Ucenik> Ucenici { get { return this._ucenici; } }

        public PodatkovniKontekst() {
            this._ucenici = UcitajUcenike();
        }

        private string datUcenici = "ucenici.dat";


        //učitavanje podataka
        private List<Ucenik> UcitajUcenike() {
            List<Ucenik> ucenici = new List<Ucenik>();

            if (File.Exists(datUcenici)) {
                using (StreamReader sr = new StreamReader(datUcenici)) {
                    while (!sr.EndOfStream) {
                        string linija = sr.ReadLine();
                        //Splitamo liniju i def. objekt učenik
                        string[] polja = linija.Split('|');

                        Ucenik u = new Ucenik();
                        u.OIB = polja[0];
                        u.Ime = polja[1];
                        u.Prezime = polja[2];
                        u.Adresa = polja[3];
                        u.Telefon = polja[4];
                        u.Razred = int.Parse(polja[5]);

                        //Dodajemo pročitanog učenika u listu
                        ucenici.Add(u);
                    }
                }
            }
            return ucenici;
        }

        //svaki zapis spremamo kao redak s poljima odvojenim znakom |
        public void SpremiUcenike() {
            using (StreamWriter sw = new StreamWriter(datUcenici))
            {
                foreach (Ucenik u in this.Ucenici) {
                    sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}",
                        u.OIB, u.Ime, u.Prezime, u.Adresa, u.Telefon, u.Razred);
                }
            }
        }

        public void DodajUcenika(Ucenik u) {
            this.Ucenici.Add(u);
            SpremiUcenike();
        }

        public void BrisiUcenika(Ucenik u) {
            this.Ucenici.Remove(u);
            SpremiUcenike();
        }

    }
}
