using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knjiznica.Model
{
    public class Ucenik : IComparable
    {
        public string OIB { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }

        public int Razred { get; set; }

        public override string ToString()
        {
            return this.OIB + "\t" + this.Prezime + "\t" + this.Ime + "\t" + this.Razred;
        }

        public int CompareTo(object obj) { 
            int rez = this.Prezime.CompareTo(((Ucenik)obj).Prezime);
            if (rez == 0) {
                rez = this.Ime.CompareTo(((Ucenik)obj).Ime);
            }

            return rez;
        }
    }
}
