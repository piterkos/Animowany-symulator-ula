using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Animowany_symlator_ula
{
    class Pszczola
    {
        const double KonsumpcjaMiodu = 0.5;
        const int Ruch = 3;
        const double MinNekataruNaKwiatku = 1.5;
        const int OkresKariery = 1000;

        public int Wiek { get; private set; }
        public bool Wulu { get; private set; }
        public double ZebranyNektar { get; private set; }

        private Point polozenie;
        public Point Polozenie { get { return polozenie; } }

        private int ID;
        private Kwiat obecnyKwiat;
        private Ul ul;
        private World swiat;

        public StanPszczoly ObecnyStanPszczoly { get; private set; } 

        public Pszczola(int id, Point polozenie, Ul ul, World swiat)
        {
            this.ul = ul;
            this.swiat = swiat;
            this.ID = id;
            Wiek = 0;
            this.polozenie = polozenie;
            Wulu = true;
            obecnyKwiat = null;
            ZebranyNektar = 0;
            ObecnyStanPszczoly = StanPszczoly.Spoczynek;
        }
        public void Go( Random losuj)
        {
            Wiek++;
            switch (ObecnyStanPszczoly)
            {
                case StanPszczoly.Spoczynek:
                    if (Wiek > OkresKariery)
                        ObecnyStanPszczoly = StanPszczoly.Emerytka;
                    break;
                case StanPszczoly.LotDoKwiatka:
                    //TODO: wprowadzić funkcje lotu do celu ( kwiatka)
                    break;
                case StanPszczoly.PobieranieNektaru:
                    double nektar = obecnyKwiat.ZbierzNektar();
                    if (nektar > 0)
                        ZebranyNektar += nektar;
                    else
                        ObecnyStanPszczoly = StanPszczoly.PowrotDoUla;
                    break;
                case StanPszczoly.PowrotDoUla:
                    if (!Wulu)
                    {
                        //TODO: Stworzyć metodę lotu do ula
                    }
                    else
                    {
                        ObecnyStanPszczoly = StanPszczoly.Spoczynek;
                    }
                    break;
                case StanPszczoly.RobiMiod:
                    if (ZebranyNektar<0.5)
                    {
                        ZebranyNektar = 0;
                        ObecnyStanPszczoly = StanPszczoly.Spoczynek;
                    }
                    else
                    {
                        //TODO: Zamiana nektaru w miód i dodanie do zapasów ula
                    }
                    break;
                case StanPszczoly.Emerytka:
                    break;
            }
        }
        private bool RuchDoCelu(Point cel)
        {
            if (Math.Abs(cel.X - polozenie.X) <= Ruch &&
                Math.Abs(cel.Y - polozenie.X) <= Ruch)
                return true;

            if (cel.X > polozenie.X)
                polozenie.X += Ruch;
            else if (cel.X < polozenie.X)
                polozenie.X -= Ruch;

            if (cel.Y > polozenie.Y)
                polozenie.Y += Ruch;
            else if (cel.Y < polozenie.Y)
                polozenie.Y -= Ruch;

            return false;
        }
    }
}
