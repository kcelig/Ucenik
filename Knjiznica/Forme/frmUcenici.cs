using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//1. uključiti namespace
using Knjiznica.Model; 

namespace Knjiznica.Forme
{
    public partial class Ucenici : Form //2.a. preimenovati u Ucenici
    {
        public Ucenici(PodatkovniKontekst kontekst) //2.b. preimenovati u Ucenici
        {
            InitializeComponent();
            this.kontekst = kontekst;       //4.dodati kontekst u inicijalizaciju
        }
        private PodatkovniKontekst kontekst;  //3. dodati kontekst


        //6. pozvati metodu PrikaziUcenike() prilikom loadanje forme
        private void Ucenici_Load(object sender, EventArgs e)
        {
            //na učitavanju forme prikazujemo učenike
            PrikaziUcenike();
        }

        //5. pozivanje statičke metode iz klase Pomocna za prikaz učenika
        private void PrikaziUcenike() {
            Forme.Pomocna.PrikaziListuUListBoxu<Ucenik>(this.kontekst.Ucenici, lbUcenici);
        }

        //7. dodati click za dodavanje
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            UDetalji frmUDetalji = new UDetalji();

            if (frmUDetalji.ShowDialog() == DialogResult.OK) {
                this.kontekst.DodajUcenika(frmUDetalji.U);
                PrikaziUcenike();
            }
        }

        //8. dodati click za uređivanje
        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (lbUcenici.SelectedIndex < 0)
            {
                MessageBox.Show("Niste odabrali učenika");
            }
            else {
                UDetalji frmUDetalji = new UDetalji();
                frmUDetalji.U = (Ucenik)lbUcenici.SelectedItem;

                if (frmUDetalji.ShowDialog() == DialogResult.OK) {
                    this.kontekst.SpremiUcenike();
                    PrikaziUcenike();
                }
            }
        }

        //9. dodati klik za brisanje
        private void btnBrisi_Click(object sender, EventArgs e)
        {
            if (lbUcenici.SelectedIndex < 0)
            {
                MessageBox.Show("Niste odabrali učenika");
            }
            else {
                this.kontekst.BrisiUcenika((Ucenik)lbUcenici.SelectedItem);
                PrikaziUcenike();
            }
        }
    }
}
