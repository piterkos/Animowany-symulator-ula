using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private UlForm ulForm = new UlForm();
        private PoleForm poleForm = new PoleForm();
        private Renderer renderuj;

        public Form1()
        {
            InitializeComponent();

            UstawPotomneOkna();
            ulForm.Show(this);
            poleForm.Show(this);
            ResetujSymulator();

            timer1.Interval = 50;
            timer1.Tick += new EventHandler(KlatkaGo);
            timer1.Enabled = false;
            StatystykiOdswiez(new TimeSpan());
        }

        private void UstawPotomneOkna()
        {
            ulForm.Location = new Point(Location.X + Width + 10, Location.Y);
            poleForm.Location = new Point(Location.X, Location.Y + Math.Max(Height, ulForm.Height) + 10);
        }

        private void ResetujSymulator()
        {
            liczbaKlatek = 0;
            swiat = new World(new WiadomoscOdPszczoly(WyslijWiadomosc));
            renderuj = new Renderer(poleForm, ulForm, swiat);
        }

        private void KlatkaGo(object sender, EventArgs e)
        {
            liczbaKlatek++;
            swiat.Go(losuj);
            //rysuj.Renderuj();
            stop = DateTime.Now;
            TimeSpan interwal = stop - start;
            start = stop;
            StatystykiOdswiez(interwal);
            ulForm.Invalidate();
            poleForm.Invalidate();
        }
        private void StatystykiOdswiez(TimeSpan interwal)
        {
            lbl_iloscPszczol.Text = swiat.Pszczoly.Count.ToString();
            lbl_iloscKwiatkow.Text = swiat.Kwiatki.Count.ToString();
            lbl_iloscMioduWulu.Text = swiat.UL.Miod.ToString("f0");
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
            timer1.Stop();
            World zapisanySwiat = swiat;
            int zapisanaLiczbaKlatek = liczbaKlatek;
            OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Plik pszczół (*.psc)|*.psc|Wszystkie pliki (*.*)|*.*",
                Title = " Wskaż plik z zapisanym stanem pszczół"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream otworz = File.OpenRead(open.FileName))
                    {
                        swiat = (World)bf.Deserialize(otworz);
                        liczbaKlatek = (int)bf.Deserialize(otworz);
                    }
                }
                catch (Exception)
                {
                    swiat = zapisanySwiat;
                    liczbaKlatek = zapisanaLiczbaKlatek;
                    MessageBox.Show("Błąd w odczycie danych z pliku.");
                }
            }
            swiat.UL.infoOdPszczoly = new WiadomoscOdPszczoly(WyslijWiadomosc);
            foreach (Pszczola biene in swiat.Pszczoly)
            {
                biene.PszczolaInfo = new WiadomoscOdPszczoly(WyslijWiadomosc);
            }
            timer1.Start();
            Renderer renderuj = new Renderer(poleForm, ulForm, swiat);
        }
        private void ZapiszToolStripButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SaveFileDialog save = new SaveFileDialog()
            {
                Title = "Wskaż plik do zapisu...",
                Filter = "Plik pszczół (*.psc)|*.psc|Wszystkie pliki (*.*)|*.*"
            };
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
                    MessageBox.Show("Wystąpił problem z zapisem");
                }
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            UstawPotomneOkna();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            renderuj.RuszajPszczołami();
        }

        private void drukujToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDocument dokument = new PrintDocument();
            dokument.PrintPage += Dokument_PrintPage;
            PrintPreviewDialog podgląd = new PrintPreviewDialog();
            podgląd.Document = dokument;
            podgląd.Show();
        }

        private void Dokument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics grafikuj = e.Graphics;
            Size rozmiarStringa;
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            //e.PageSettings.Margins.Left = 10;
            using (Font arial24pogrubiony = new Font("Arial", 24, FontStyle.Bold))
            {
                rozmiarStringa = Size.Ceiling(grafikuj.MeasureString("Symulator ula", arial24pogrubiony));
                grafikuj.FillEllipse(Brushes.Gray, new Rectangle(e.MarginBounds.X + 2, e.MarginBounds.Y + 2, rozmiarStringa.Width + 30, rozmiarStringa.Height + 30));
                grafikuj.FillEllipse(Brushes.Black, new Rectangle(e.MarginBounds.X, e.MarginBounds.Y, rozmiarStringa.Width + 30, rozmiarStringa.Height + 30));
                grafikuj.DrawString("Symulator ula", arial24pogrubiony, Brushes.Gray, e.MarginBounds.X + 17, e.MarginBounds.Y + 17);
                grafikuj.DrawString("Symulator ula", arial24pogrubiony, Brushes.White, e.MarginBounds.X + 15, e.MarginBounds.Y + 15);

                int tabelaX = e.MarginBounds.X + rozmiarStringa.Width + 50;
                int tabelaSzerokość = e.MarginBounds.X + e.MarginBounds.Width - tabelaX + 50;
                int pierwszaKolumnaX = tabelaX + 2;
                int drugaKolumna = tabelaX + (tabelaSzerokość / 2) + 56;
                int tabelaY = e.MarginBounds.Y;

                tabelaY = DrukujTabele(e.Graphics, tabelaX, tabelaSzerokość, tabelaY, pierwszaKolumnaX, drugaKolumna, "Ilość pszczół", lbl_iloscPszczol.Text);
                tabelaY = DrukujTabele(e.Graphics, tabelaX, tabelaSzerokość, tabelaY, pierwszaKolumnaX, drugaKolumna, "Ilość kwiatów", lbl_iloscKwiatkow.Text);
                tabelaY = DrukujTabele(e.Graphics, tabelaX, tabelaSzerokość, tabelaY, pierwszaKolumnaX, drugaKolumna, "Ilość miodu w ulu", lbl_iloscMioduWulu.Text);
                tabelaY = DrukujTabele(e.Graphics, tabelaX, tabelaSzerokość, tabelaY, pierwszaKolumnaX, drugaKolumna, "Ilość nektaru na polu", lbl_nektarNaKwiatkach.Text);
                tabelaY = DrukujTabele(e.Graphics, tabelaX, tabelaSzerokość, tabelaY, pierwszaKolumnaX, drugaKolumna, "Ilość wyświetlanych klatek", lbl_iloscKlatek.Text);
                tabelaY = DrukujTabele(e.Graphics, tabelaX, tabelaSzerokość, tabelaY, pierwszaKolumnaX, drugaKolumna, "Ilość klatek na sekundę", lbl_iloscKlatekNaSek.Text);

                using (Pen czarnyPisak = new Pen(Brushes.Black, 2))
                using (Bitmap ulBitmap = new Bitmap(ulForm.ClientSize.Width, ulForm.ClientSize.Height))
                using (Bitmap poleBitmap = new Bitmap(poleForm.ClientSize.Width, poleForm.ClientSize.Height))
                {
                    using (Graphics ulGrafika = Graphics.FromImage(ulBitmap))
                    {
                        renderuj.RysujUl(ulGrafika);
                    }
                    int środekX = e.PageBounds.Width /2;
                    int szerokoścObrazka = e.MarginBounds.Width / 2;
                    // wstawienie obrazu ula na środku wydruku
                    grafikuj.DrawImage(ulBitmap,środekX - szerokoścObrazka /2,tabelaY + 50,szerokoścObrazka,ulBitmap.Height);
                    // tworzenie obramowania wokół ula
                    grafikuj.DrawRectangle(czarnyPisak, środekX - szerokoścObrazka / 2, tabelaY + 50, ulBitmap.Width, ulBitmap.Height);
                    using (Graphics poleGrafika = Graphics.FromImage(poleBitmap))
                    {
                        renderuj.RysujPole(poleGrafika);
                    }
                    float pierwotnaWyosokość = poleBitmap.Size.Height;
                    float pierwotnaSzerokość = poleBitmap.Size.Width;
                    float proporcja = pierwotnaWyosokość / pierwotnaSzerokość;
                    float nowaWysokość = e.MarginBounds.Width * proporcja;
                    float nowaSzerokość = e.MarginBounds.Width;
                    grafikuj.DrawImage(poleBitmap, e.MarginBounds.X,e.MarginBounds.Bottom-nowaWysokość,nowaSzerokość,nowaWysokość);
                    //grafikuj.DrawImage(poleBitmap, e.MarginBounds.X, e.MarginBounds.Height - wysokośćPoleFoto, e.MarginBounds.Width, wysokośćPoleFoto);
                }
                timer1.Enabled = true;
            }
        }
        private int DrukujTabele(Graphics drukujGrafikę, int tabelaX, int tabelaSzerokość, 
            int tabelaY, int pierwszaKolumnaX, int drugaKolumnaX, string pierwszaKolumna, string drugaKolumna)
        {
            Font arial12 = new Font("Arial", 12);
            Size rozmiarStringa = Size.Ceiling(drukujGrafikę.MeasureString(pierwszaKolumna, arial12));
            tabelaY += 2;
            drukujGrafikę.DrawString(pierwszaKolumna, arial12, Brushes.Black, pierwszaKolumnaX, tabelaY);
            drukujGrafikę.DrawString(drugaKolumna, arial12, Brushes.Black, drugaKolumnaX, tabelaY);
            tabelaY += rozmiarStringa.Height + 2;
            drukujGrafikę.DrawLine(Pens.Black, tabelaX, tabelaY, tabelaX + tabelaSzerokość, tabelaY);
            arial12.Dispose();
            return tabelaY;
        }
    }
}
