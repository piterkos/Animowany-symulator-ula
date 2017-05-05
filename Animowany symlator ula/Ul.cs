using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animowany_symlator_ula
{
    class Ul
    {
        const int poczatkowaLiczbaPszczol = 6;
        const double poczatkowaIloscMiodu = 3.2;
        const double maxIloscZapasow = 15;
        const double wspolcznnikProporcjiPrzyProdukcji = 0.25;
        const int maxLiczbaPszczol = 8;
        const double minMioduDoProdukcjiPszczoly = 4;

        public double Miod { get; private set; }
        public Dictionary<string, Point> lokalizacja { get; private set; }
        private int IDliczbaPszczol = 0;
        private World swiat;

        public Ul(World swiat)
        {
            this.swiat = swiat;
            Miod = poczatkowaIloscMiodu;
            UstawLokalizacjeWulu();
            Random losuj = new Random();
            for (int i = 0; i < poczatkowaLiczbaPszczol; i++)
            {
                DodajPszczole(losuj);
            }
        }
        /// <summary>
        /// pobiera lokalizację w postaci string i zwraca przypisany do tej lokacji Point
        /// </summary>
        /// <param name="lokal">lokalizacja w ulu w postaci stringa</param>
        /// <returns></returns>
        public Point PobierzLokalizacje(string lokal)
        {
            if (lokalizacja.ContainsKey(lokal))
            {
                return lokalizacja[lokal];
            }
            else
                throw new ArgumentException("Brak takiej lokalizacji: " + lokal);
        }
        /// <summary>
        /// ustawia lokalizacje w ulu na konkretne punkty (POINT)
        /// </summary>
        public void UstawLokalizacjeWulu()
        {
            lokalizacja = new Dictionary<string, Point>();
            lokalizacja.Add("Wejście", new Point(600, 100));
            lokalizacja.Add("Żłobek", new Point(95, 174));
            lokalizacja.Add("Fabryka", new Point(157, 98));
            lokalizacja.Add("Wyjście", new Point(194, 213));
        }
        /// <summary>
        /// ustawiamy ilość na jaką mona zamienić nektar i czy ewentualnie jest tyle miejsca w ulu na
        /// jego przechowanie, jeżeli nie to zwróć false
        /// jeżeli tak to dodaj wytworzony miod do zapasow i zwróc true
        /// </summary>
        /// <param name="nektar">ilość nektaru do obróbki</param>
        /// <returns>zwraca prawdę lub fałsz w zależności czy ul posiada miejsce na dodatkowy miód
        /// </returns>
        public bool DodajMiod(double nektar)
        {
            double miodDoDodania = nektar * wspolcznnikProporcjiPrzyProdukcji;
            if (Miod + miodDoDodania > maxIloscZapasow)
                return false;
            Miod += miodDoDodania;
            return true;
        }
        /// <summary>
        /// Zwraca True i odejmuje ilość od zapasów miodu
        /// </summary>
        /// <param name="ilosc">ilość miodu do dodania do zapasów</param>
        /// <returns>przy braku wystarczającej ilości zwracamy fałsz</returns>
        public bool KosumpcjaMiodu(double ilosc)
        {
            if (ilosc > Miod)
                return false;
            else
            {
                Miod -= ilosc;
                return true;
            }
        }
        /// <summary>
        /// Dodaje nową pszczołę, gdy jest wystarczająca ilość miodu,
        /// a także dodany został współczynnik losowości wynoszący 10% na to, że pszczoła zostanie stworzona
        /// </summary>
        /// <param name="losuj"></param>
        public void Go(Random losuj)
        {
            if (swiat.Pszczoly.Count < maxLiczbaPszczol && Miod > minMioduDoProdukcjiPszczoly && losuj.Next(10)==1)
                DodajPszczole(losuj);
        }
        /// <summary>
        /// Tworzy nową pszczołę i tworzy dla niej punkt startowy gdzieś w żłobku, poprzez losowy wybór tego obszaru
        /// </summary>
        /// <param name="losuj"></param>
        private void DodajPszczole(Random losuj)
        {
            IDliczbaPszczol++;
            int r1 = losuj.Next(100) - 50;
            int r2 = losuj.Next(100) - 50;
            Point punktStartowy = new Point(lokalizacja["Żłobek"].X + r1, lokalizacja["Żłobek"].Y + r2);
            Pszczola nowaPszczola = new Pszczola(IDliczbaPszczol, punktStartowy, this, swiat);
            swiat.Pszczoly.Add(nowaPszczola);
        }
    }
}
