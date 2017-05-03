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
        private int liczbaPszczol = 0;

        public Ul()
        {
            Miod = poczatkowaIloscMiodu;
            UstawLokalizacjeWulu();
            Random losuj = new Random();
            for (int i = 0; i < poczatkowaLiczbaPszczol; i++)
            {
                DodajPszczole(losuj);
            }
        }
        public Point PobierzLokalizacje(string lokal)
        {
            if (lokalizacja.ContainsKey(lokal))
            {
                return lokalizacja[lokal];
            }
            else
                throw new ArgumentException("Brak takiej lokalizacji");
        }
        public void UstawLokalizacjeWulu()
        {
            lokalizacja = new Dictionary<string, Point>();
            lokalizacja.Add("Wejście", new Point(600, 100));
            lokalizacja.Add("Żłobek", new Point(95, 174));
            lokalizacja.Add("Fabryka", new Point(157, 98));
            lokalizacja.Add("Wyjście", new Point(194, 213));
        }
        public bool DodajMiod(double Nektar)
        {
            throw new NotImplementedException();
        }
        public bool KosumpcjaMiodu(double ilosc)
        {
            throw new NotImplementedException();
        }
        public void Go(Random losuj)
        {
            throw new NotImplementedException();
        }
        private void DodajPszczole(Random losuj)
        {
            throw new NotImplementedException();
        }
    }
}
