using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Knjiznica.Model;    //moramo uključiti da bi public PodatkovniKontekst Kontekst; bio vidlljiv

namespace Knjiznica.Forme
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }

        public PodatkovniKontekst Kontekst;

        private void Glavna_Load(object sender, EventArgs e)
        {
            try {
                this.Kontekst = new PodatkovniKontekst();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ucenici_Click(object sender, EventArgs e)
        {
            Ucenici frmUcenici = new Ucenici(this.Kontekst);
            frmUcenici.ShowDialog();

        }
    }
}
