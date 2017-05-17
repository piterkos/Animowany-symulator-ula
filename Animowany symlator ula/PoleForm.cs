using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animowany_symlator_ula
{
    public partial class PoleForm : Form
    {
        public Renderer Rysuj { get; set; }
        public World świat;
        public Ul ul;
        Random losuj;
        public PoleForm()
        {
            InitializeComponent();
        }

        private void PoleForm_MouseClick(object sender, MouseEventArgs e)
        {
            // Przerysuj();      
            // graphics.FillEllipse(Brushes.Yellow, new Rectangle(50, 15, 70, 70));
            losuj = new Random();
            Rectangle słońce = new Rectangle(50, 15, 70, 70);
            Rectangle ul = new Rectangle(550,20, Rysuj.UlZewnątrz.Width,Rysuj.UlZewnątrz.Height);
            Point klikniętyObszar = new Point(e.Location.X, e.Location.Y);
            if (słońce.Contains(klikniętyObszar))
                świat.DodajKwiatka(losuj);
            if (ul.Contains(klikniętyObszar))
                świat.UL.DodajPszczole(losuj);
            
        }
        public void rysujPszczołę(Graphics graf, Rectangle zakres)
        {
            graf.DrawImage(Properties.Resources.Pszczoła_1,zakres);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Przerysuj();
        }

        //private void Przerysuj()
        //{
        //    PictureBox zdjęciePszczoły = new PictureBox();            
        //}

        private void PoleForm_Paint(object sender, PaintEventArgs e)
        {
            Rysuj.RysujPole(e.Graphics);
        }
    }
}
