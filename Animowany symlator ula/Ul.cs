﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animowany_symlator_ula
{
    [Serializable]
    public class Ul
    {
        const int poczatkowaLiczbaPszczol = 6;
        const double poczatkowaIloscMiodu = 3.2;
        const double maxIloscZapasow = 15;
        const double wspolcznnikProporcjiPrzyProdukcji = 0.25;
        const int maxLiczbaPszczol = 20;
        const double minMioduDoProdukcjiPszczoly = 4;

        public double Miod { get; private set; }
        public Dictionary<string, Point> Lokalizacja { get; private set; }
        private int IDliczbaPszczol = 0;
        private World swiat;
        [NonSerialized]
        public WiadomoscOdPszczoly infoOdPszczoly;

        public Ul(World swiat, WiadomoscOdPszczoly infoOdPszczoly)
        {
            this.swiat = swiat;
            Miod = poczatkowaIloscMiodu;
            UstawLokalizacjeWulu();
            this.infoOdPszczoly = infoOdPszczoly;
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
            if (Lokalizacja.ContainsKey(lokal))
            {
                return Lokalizacja[lokal];
            }
            else
                throw new ArgumentException("Brak takiej lokalizacji: " + lokal);
        }
        /// <summary>
        /// ustawia lokalizacje w ulu na konkretne punkty (POINT)
        /// </summary>
        public void UstawLokalizacjeWulu()
        {
            Lokalizacja = new Dictionary<string, Point>
            {
                { "Wejście", new Point(614, 103) },
                { "Żłobek", new Point(108, 218) },
                { "Fabryka miodu", new Point(207, 109) },
                { "Wyjście", new Point(228, 240) }
            };
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
        public void DodajPszczole(Random losuj)
        {
            IDliczbaPszczol++;
            int r1 = losuj.Next(100) - 50;
            int r2 = losuj.Next(100) - 50;
            Point punktStartowy = new Point(Lokalizacja["Żłobek"].X + r1, Lokalizacja["Żłobek"].Y + r2);
            Pszczola nowaPszczola = new Pszczola(IDliczbaPszczol, punktStartowy, this, swiat);
            nowaPszczola.PszczolaInfo += this.infoOdPszczoly;
            swiat.Pszczoly.Add(nowaPszczola);
        }
    }
}
