using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Animowany_symlator_ula
{
    [Serializable]
    class Pszczola
    {
        const double KonsumpcjaMioduPotrzebnaDoDzialania = 0.5;
        const int Ruch = 3;
        const double MinNekataruNaKwiatku = 1.5;
        const int OkresKariery = 1000;

        public int Wiek { get; private set; }
        public bool Wulu { get; private set; }
        public double ZebranyNektar { get; private set; }

        private Point obecnePolozenie;
        public Point Polozenie { get { return obecnePolozenie; } }

        private int ID;
        private Kwiat kwiatCel;
        private Ul ul;
        private World swiat;

        public StanPszczoly ObecnyStanPszczoly { get; private set; }
        [NonSerialized]
        public WiadomoscOdPszczoly PszczolaInfo;

        public Pszczola(int id, Point polozenie, Ul ul, World swiat)
        {
            this.ul = ul;
            this.swiat = swiat;
            this.ID = id;
            Wiek = 0;
            this.obecnePolozenie = polozenie;
            Wulu = true;
            kwiatCel = null;
            ZebranyNektar = 0;
            ObecnyStanPszczoly = StanPszczoly.Spoczynek;
        }
        public void Go( Random losuj)
        {
            Wiek++;
            StanPszczoly staryStan = ObecnyStanPszczoly;
            switch (ObecnyStanPszczoly)
            {
                case StanPszczoly.Spoczynek:
                    if (Wiek > OkresKariery)
                    {
                        ObecnyStanPszczoly = StanPszczoly.Emerytka;
                    }
                    else if (swiat.Kwiatki.Count > 0 && ul.KosumpcjaMiodu(KonsumpcjaMioduPotrzebnaDoDzialania))
                    {
                        Kwiat kwiatek = swiat.Kwiatki[losuj.Next(swiat.Kwiatki.Count)];
                        if (kwiatek.Zywot && kwiatek.Nektar >= MinNekataruNaKwiatku)
                        {
                            kwiatCel = kwiatek;
                            ObecnyStanPszczoly = StanPszczoly.LotDoKwiatka;
                        }
                    }
                    break;
                case StanPszczoly.LotDoKwiatka:
                    // jeżeli wśród kwiatków nie ma kwiatka-celu to zmień stan na powrót do ula
                    // czyli czy czasami w czasie lotu do kwiatka, kwiatek nie obumarł
                    if (!swiat.Kwiatki.Contains(kwiatCel))
                        ObecnyStanPszczoly = StanPszczoly.PowrotDoUla;
                    // jeżeli pszczoła znajduje się w ulu...
                    else if (Wulu)
                    {
                        // jest w "Wyjściu" to zmień pole "Wulu" na false,
                        // a położenie na "Wejście"
                        if (RuchDoCelu(ul.PobierzLokalizacje("Wyjście")))
                        {
                            Wulu = false;
                            obecnePolozenie = ul.PobierzLokalizacje("Wejście");
                        }
                    }
                    else
                    {
                        // jeżeli po wykonaniu ruchu cel został osiągnięty to zmień stan pszczoły na: pobieranie nektaru.
                        if (RuchDoCelu(kwiatCel.Polozenie))
                            ObecnyStanPszczoly = StanPszczoly.PobieranieNektaru;
                    }
                    break;
                case StanPszczoly.PobieranieNektaru:
                    double nektar = kwiatCel.ZbierzNektar();
                    if (nektar > 0)
                        ZebranyNektar += nektar;
                    else
                        ObecnyStanPszczoly = StanPszczoly.PowrotDoUla;
                    break;
                case StanPszczoly.PowrotDoUla:
                    if (!Wulu) // jeśli jesteś poza ulem
                    {
                        // to jeśli jesteś na wejściu to zmień położenie na wyjście z ula i wartość "Wulu" na "Wyjście"
                        if (RuchDoCelu(ul.PobierzLokalizacje("Wejście")))
                        {
                            Wulu = true;
                            obecnePolozenie = ul.PobierzLokalizacje("Wyjście");
                        }
                    }
                    else
                    {
                        // jeśli jest w ulu to gdy będzie w fabryce miodu to zmień stan na robi miód
                        if(RuchDoCelu(ul.PobierzLokalizacje("Fabryka miodu")))
                            ObecnyStanPszczoly = StanPszczoly.RobiMiod;
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
                        if (ul.DodajMiod(0.5))   // jeżeli da sie dodać do ula miód
                            ZebranyNektar -= 0.5;// odejmij nektar pszczole
                        else
                            ZebranyNektar = 0;  // jeżeli w ulu nie ma miejsca to pszczoła porzuca nektar i może działać dalej
                    }
                    break;
                case StanPszczoly.Emerytka:
                    break;
            }
            if (staryStan!=ObecnyStanPszczoly && PszczolaInfo !=null)
            {
                string infoStan;
                switch (ObecnyStanPszczoly)
                {
                    case StanPszczoly.Spoczynek:
                        infoStan = "bezrobotna";
                        break;
                    case StanPszczoly.LotDoKwiatka:
                        infoStan = "leci do kwiatków";
                        break;
                    case StanPszczoly.PobieranieNektaru:
                        infoStan = "pobiera nektar";
                        break;
                    case StanPszczoly.PowrotDoUla:
                        infoStan = "powraca do ula";
                        break;
                    case StanPszczoly.RobiMiod:
                        infoStan = "robi miód";
                        break;
                    case StanPszczoly.Emerytka:
                        infoStan = "na emeryturze";
                        break;
                    default:
                        infoStan = "bezrobotna";
                        break;
                }
                PszczolaInfo(ID, infoStan);
            }
        }

        
    
        /// <summary>
        /// porusza pszczołę w kierunku celu i gdy jest na miejscu to zwraca true, jeśli nie to false
        /// </summary>
        /// <param name="cel"></param>
        /// <returns>true - cel osiągnięty, false - cel jeszcze nie osiągnięty</returns>
        private bool RuchDoCelu(Point cel)
        {
            if (Math.Abs(cel.X - obecnePolozenie.X) <= Ruch &&
                Math.Abs(cel.Y - obecnePolozenie.Y) <= Ruch)
                return true;

            if (cel.X > obecnePolozenie.X)
                obecnePolozenie.X += Ruch;
            else if (cel.X < obecnePolozenie.X)
                obecnePolozenie.X -= Ruch;

            if (cel.Y > obecnePolozenie.Y)
                obecnePolozenie.Y += Ruch;
            else if (cel.Y < obecnePolozenie.Y)
                obecnePolozenie.Y -= Ruch;

            return false;
        }
    }
}
