using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databaseProject
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            odalar odalar = new odalar();
            odalar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciBilgileri od = new OgrenciBilgileri();
            od.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fiyatlar fiyatlar = new Fiyatlar();
            fiyatlar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AileBilgileri aileBilgileri = new AileBilgileri();
            aileBilgileri.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eftler eftler = new Eftler();
            eftler.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OdemeBilgileri odemeBilgileri = new OdemeBilgileri();
            odemeBilgileri.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GirisCikis girisCikis = new GirisCikis();
            girisCikis.Show();
        }
    }
}
