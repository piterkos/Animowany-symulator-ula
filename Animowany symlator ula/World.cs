using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animowany_symlator_ula
{
    [Serializable]
    public class World
    {
        private const double ZbiorNektaruNaNowegoKwiatka = 50;
        private const int PoleMinX = 15;
        private const int PoleMinY = 177;
        private const int PoleMaxX = 700;
        private const int PoleMaxY = 400;

        public Ul UL;
        public List<Pszczola> Pszczoly;
        public List<Kwiat> Kwiatki;

        public World(WiadomoscOdPszczoly infoVonPszczola)
        {
            Pszczoly = new List<Pszczola>();
            Kwiatki = new List<Kwiat>();
            UL = new Ul(this,infoVonPszczola);
            Random losuj = new Random();
            for (int i = 0; i < 10; i++)
            {
                DodajKwiatka(losuj);
            }
            
        }
        /// <summary>
        /// Dodaj nowego kwiatka w losowej lokalizacji z zakresu Pola określonego przez stałe
        /// </summary>
        /// <param name="losuj"></param>
        public void DodajKwiatka(Random losuj)
        {
            Point lokalizacja = new Point(losuj.Next(PoleMinX, PoleMaxX), losuj.Next(PoleMinY, PoleMaxY));
            Kwiat nowyKwiat = new Kwiat(lokalizacja, losuj);
            Kwiatki.Add(nowyKwiat);
        }
        
        /// <summary>
        /// uruchomienie rozgrywki, polegające na uruchomieniu metod Go() każdej z  instancji klas
        /// </summary>
        /// <param name="losuj"></param>
        public void Go(Random losuj )
        {

            UL.Go(losuj);

            for (int i = Pszczoly.Count-1; i >= 0; i--)
            {
                Pszczoly[i].Go(losuj);
                if (Pszczoly[i].ObecnyStanPszczoly == StanPszczoly.Emerytka)
                    Pszczoly.Remove(Pszczoly[i]);
            }

            double calkowiteZbioryNektaru = 0;
            for (int i = Kwiatki.Count - 1 ; i >= 0; i--)
            {
                Kwiatki[i].Go();
                calkowiteZbioryNektaru += Kwiatki[i].NektarZbiory;
                if (!Kwiatki[i].Zywot)
                    Kwiatki.Remove(Kwiatki[i]);
            }
            if (calkowiteZbioryNektaru > ZbiorNektaruNaNowegoKwiatka)
            {
                foreach (Kwiat kwiat in Kwiatki)
                {
                    kwiat.NektarZbiory = 0;
                    DodajKwiatka(losuj);
                }
            }
        }
    }
}
