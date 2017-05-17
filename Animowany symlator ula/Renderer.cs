using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animowany_symlator_ula
{
    public class Renderer
    {
        private int ruch = 0;
        private int klatka = 0;

        private PoleForm poleForm;
        private UlForm ulForm;
        private World świat;

        private Bitmap UlŚrodek;
        public Bitmap UlZewnątrz;
        private Bitmap Kwiat;

        private Bitmap[] PszczołaAnimacjaMała;
        private Bitmap[] PszczołaAnimacjaDuża;
        /// <summary>
        /// ustawia odpowiednie rozmiary zdjęć oraz animacji
        /// </summary>
        private void ZainicjujObrazy()
        {
            UlZewnątrz = ZmieńRozmiar(Properties.Resources.Ul___zewnątrz__, 120,145);
            UlŚrodek = ZmieńRozmiar(Properties.Resources.Ul___wewnątrz__, ulForm.ClientRectangle.Width, ulForm.ClientRectangle.Height);
            Kwiat = ZmieńRozmiar(Properties.Resources.Kwiat, 75, 75);

            PszczołaAnimacjaMała = new Bitmap[4];
            PszczołaAnimacjaMała[0] = ZmieńRozmiar(Properties.Resources.Pszczoła_1, 20, 20);
            PszczołaAnimacjaMała[1] = ZmieńRozmiar(Properties.Resources.Pszczoła_2, 20, 20);
            PszczołaAnimacjaMała[2] = ZmieńRozmiar(Properties.Resources.Pszczoła_3, 20, 20);
            PszczołaAnimacjaMała[3] = ZmieńRozmiar(Properties.Resources.Pszczoła_4, 20, 20);
            PszczołaAnimacjaDuża = new Bitmap[4];
            PszczołaAnimacjaDuża[0] = ZmieńRozmiar(Properties.Resources.Pszczoła_1, 40, 40);
            PszczołaAnimacjaDuża[1] = ZmieńRozmiar(Properties.Resources.Pszczoła_2, 40, 40);
            PszczołaAnimacjaDuża[2] = ZmieńRozmiar(Properties.Resources.Pszczoła_3, 40, 40);
            PszczołaAnimacjaDuża[3] = ZmieńRozmiar(Properties.Resources.Pszczoła_4, 40, 40);
        }

        public static Bitmap ZmieńRozmiar(Bitmap zdjęcie, int szerokość, int wysokość)
        {
            Bitmap zmienioneZdjęcie = new Bitmap(szerokość, wysokość); // tworzy nową zmienną bitmapę o rozmiarach z parametrów
            using (Graphics grafika = Graphics.FromImage(zmienioneZdjęcie))  // ustanawia "strumień" do powyższego pliku
            {
                grafika.DrawImage(zdjęcie, 0, 0, szerokość, wysokość); // rysuje na nowo powstałej bitmapie zdjęcie o odpowiednich rozmiarach
            }
            return zmienioneZdjęcie;
        }

        public Renderer(PoleForm pole, UlForm ul, World świat)
        {
            this.świat = świat;
            this.poleForm = pole;
            this.ulForm = ul;
            pole.Rysuj = this;
            ul.Rysuj = this;
            poleForm.świat = świat;
            ZainicjujObrazy();
        }

        public void RuszajPszczołami()
        {
            klatka++;
            if (klatka >= 6)
                klatka = 0;
            switch (klatka)
            {
                case 0: ruch = 0; break;
                case 1: ruch = 1; break;
                case 2: ruch = 2; break;
                case 3: ruch = 3; break;
                case 4: ruch = 2; break;
                case 5: ruch = 1; break;
                default: ruch = 0; break;
            }
            poleForm.Invalidate();
            ulForm.Invalidate();
        }

        public void RysujUl(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Aqua, ulForm.ClientRectangle);
            graphics.DrawImageUnscaled(UlŚrodek, 0, 0);
            foreach (Pszczola pszczoła in świat.Pszczoly)
            {
                if (pszczoła.Wulu)
                    graphics.DrawImageUnscaled(PszczołaAnimacjaMała[ruch], pszczoła.Polozenie.X, pszczoła.Polozenie.Y);
            }
        }

        public void RysujPole(Graphics graphics)
        {
            
            using(Pen brązowyPisak = new Pen(Color.Brown, 6.0f))
            {
                graphics.FillRectangle(Brushes.Blue, 0, 0, poleForm.Width, poleForm.Size.Height / 2);
                graphics.FillEllipse(Brushes.Yellow, new Rectangle(50, 15, 70, 70));
                graphics.FillRectangle(Brushes.Green, 0, poleForm.Height / 2, poleForm.Width, poleForm.Height);
                graphics.DrawLine(brązowyPisak, new Point(593, 0), new Point(593, 30));
                graphics.DrawImageUnscaled(UlZewnątrz, 550, 20);
                
                foreach (Kwiat kwiatek in świat.Kwiatki)
                {
                    graphics.DrawImageUnscaled(Kwiat, kwiatek.Polozenie.X, kwiatek.Polozenie.Y);
                }
                foreach (Pszczola bzyk in świat.Pszczoly)
                {
                    if(!bzyk.Wulu)
                    graphics.DrawImageUnscaled(PszczołaAnimacjaDuża[ruch], bzyk.Polozenie.X, bzyk.Polozenie.Y);
                }
            }
        }
    }
}
