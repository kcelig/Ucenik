using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//1. uključizi namespace
using Knjiznica.Model;

namespace Knjiznica.Forme
{
    public partial class UDetalji : Form  //2. preimenovati klasu
    {
        public UDetalji()
        {
            InitializeComponent();
        }

        public Ucenik U;                //3. napraviti objekt

        //3. kod za učitavanje forme
        private void frmUDetalji_Load(object sender, EventArgs e)
        {
            if (this.U != null) {
                txtOIB.Text = this.U.OIB;
                txtIme.Text = this.U.Ime;
                txtPrezime.Text = this.U.Prezime;
                txtAdresa.Text = this.U.Adresa;
                txtTelefon.Text = this.U.Telefon;
                cbRazred.Text = this.U.Razred.ToString();
            }
        }


        //4. kod za OK gumb
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtOIB.Text == "" || txtIme.Text == "" 
                || txtPrezime.Text == "" || cbRazred.Text == "")
            {
                MessageBox.Show("OIB, ime i prezime te razred su obvezni!");
                this.DialogResult = DialogResult.None;

            }
            else {
                if (this.U == null) {
                    this.U = new Ucenik();
                }

                this.U.OIB = txtOIB.Text;
                this.U.Ime = txtIme.Text;
                this.U.Prezime = txtPrezime.Text;
                this.U.Adresa = txtAdresa.Text;
                this.U.Telefon = txtTelefon.Text;
                this.U.Razred = int.Parse(cbRazred.Text);

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
