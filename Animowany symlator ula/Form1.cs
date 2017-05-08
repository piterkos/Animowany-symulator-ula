using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Animowany_symlator_ula
{
    public partial class Form1 : Form
    {
        private World swiat;
        private Random losuj = new Random();
        private DateTime start = DateTime.Now;
        private DateTime stop;
        private int liczbaKlatek = 0;

        public Form1()
        {
            InitializeComponent();
            swiat = new World(new WiadomoscOdPszczoly(WyslijWiadomosc));

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(KlatkaGo);
        }

        private void KlatkaGo(object sender, EventArgs e)
        {
            liczbaKlatek++;
            swiat.Go(losuj);
            stop = DateTime.Now;
            TimeSpan interwal = stop - start;
            start = stop;
            StatystykiOdswiez(interwal);
        }

        private void StatystykiOdswiez(TimeSpan interwal)
        {
            lbl_iloscPszczol.Text = swiat.Pszczoly.Count.ToString();
            lbl_iloscKwiatkow.Text = swiat.Kwiatki.Count.ToString();
            lbl_iloscMioduWulu.Text = swiat.UL.Miod.ToString("f0"); // TODO: zastosować format 0:f0
            double nektar = 0;
            foreach (Kwiat kwiatek in swiat.Kwiatki)
            {
                nektar += kwiatek.Nektar;
            }
            lbl_nektarNaKwiatkach.Text = nektar.ToString("f2");
            lbl_iloscKlatek.Text = liczbaKlatek.ToString();
            double milisekundy = interwal.TotalMilliseconds;
            if (milisekundy != 0.0)
                lbl_iloscKlatekNaSek.Text = string.Format("{0:f0} ({1:f1} ms)",1000 / milisekundy, milisekundy);
            else
                lbl_iloscKlatekNaSek.Text = "brak";
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            if(!timer1.Enabled)
            {
                timer1.Start();
                toolStripButton1.Text = "Zatrzymaj symulację";
                KlatkaGo(this, e);
            }
            else
            {
                toolStripButton1.Text = "Wznów symulację";
                timer1.Stop();
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            liczbaKlatek = 0;
            toolStripButton1.Text = "Rozpocznij symulację";
            swiat = new World(new WiadomoscOdPszczoly(WyslijWiadomosc));
        }
        private void WyslijWiadomosc(int ID, string wiadomosc)
        {
            statusStrip1.Items[0].Text = "Pszczoła numer " + ID + ": " + wiadomosc;
            listBox1.Items.Clear();
                        
            for (int i = 0; i < 6; i++)
            {
                int licznik = 0;
                foreach (var pszczola in swiat.Pszczoly)
                {
                    if ((StanPszczoly)i == pszczola.ObecnyStanPszczoly)
                        licznik++;
                }
                listBox1.Items.Add((StanPszczoly)i + ": " + licznik + " pszczoły\n");
            }
        }

        private void OtwórzToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void ZapiszToolStripButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream sw = File.OpenWrite(save.FileName))
                    {
                        bf.Serialize(sw, swiat);
                        bf.Serialize(sw, liczbaKlatek);
                    }
            
                
                
                }
                catch (Exception)
                {

                    throw;
                }
            }
            
        }
    }
}
