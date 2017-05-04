using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animowany_symlator_ula
{
    class Kwiat
    {
        #region stałe
        const int DlugoscZyciaMin = 15000;
        const int DlugoscZyciaMax = 30000;
        const double StartowanaIloscNektaru = 1.5;
        const double MaxIloscNektaru = 5;
        const double ZwiekszenieIlosciNektaruNaCykl = 0.01;
        const double ZbieranaIloscNaktaruNaCykl = 0.03;
        #endregion
        public Point Polozenie { get; }
        public int Wiek { get; private set; }
        public bool Zywot { get; private set; }
        public double Nektar { get; private set; }
        public double NektarZbiory { get; set; }
        private int dlugoscZycia;

        public Kwiat(Point lokalizacjaKwaitu, Random losuj)
        {
            Polozenie = lokalizacjaKwaitu;
            Wiek = 0;
            Zywot = true;
            Nektar = StartowanaIloscNektaru;
            NektarZbiory = 0;
            dlugoscZycia = losuj.Next(DlugoscZyciaMin, DlugoscZyciaMax + 1);
        }

        public double ZbierzNektar()
        {
            if (Nektar < ZbieranaIloscNaktaruNaCykl)
            {
                return 0;
            }
            else
            {
                Nektar -= ZbieranaIloscNaktaruNaCykl;
                NektarZbiory += ZbieranaIloscNaktaruNaCykl - Nektar;
                return ZbieranaIloscNaktaruNaCykl;
            }
        }
        public void Go()
        {
            Wiek++;
            if (Wiek > dlugoscZycia)
                Zywot = false;
            else
            {
                Nektar += ZwiekszenieIlosciNektaruNaCykl;
                if (Nektar > MaxIloscNektaru)
                    Nektar = MaxIloscNektaru;
            }
        }
    }
}
