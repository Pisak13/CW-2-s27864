

namespace CW_2_s27864
{
    public class Kontenerowiec
    {
        public string Nazwa { get; }
        public double MaksPredkosc { get; }
        public int MaksLiczbaKontenerow { get; }
        public double MaksLadownoscWTonach { get; }

        private List<Kontener> kontenery = new();

        public Kontenerowiec(string nazwa, double maksPredkosc, int maksKontenerow, double maksLadownoscWTonach)
        {
            Nazwa = nazwa;
            MaksPredkosc = maksPredkosc;
            MaksLiczbaKontenerow = maksKontenerow;
            MaksLadownoscWTonach = maksLadownoscWTonach;
        }

        public void ZaladujKontener(Kontener kontener)
        {
            if (kontenery.Count >= MaksLiczbaKontenerow)
                throw new InvalidOperationException("Przekroczono maksymalną liczbę kontenerów na statku.");

            double aktualnaWagaTon = kontenery.Sum(k => k.MasaLadunku) / 1000.0;
            double nowaWagaTon = aktualnaWagaTon + kontener.MasaLadunku / 1000.0;

            if (nowaWagaTon > MaksLadownoscWTonach)
                throw new InvalidOperationException("Przekroczono maksymalną wagę ładunku na statku.");

            kontenery.Add(kontener);
        }

        public void ZaladujListeKontenerow(List<Kontener> lista)
        {
            foreach (var kontener in lista)
            {
                ZaladujKontener(kontener);
            }
        }

        public void UsunKontener(string numerSeryjny)
        {
            var kontener = kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                kontenery.Remove(kontener);
                Console.WriteLine($"Kontener {numerSeryjny} usunięty ze statku {Nazwa}.");
            }
            else
            {
                Console.WriteLine($"Kontener {numerSeryjny} nie został znaleziony.");
            }
        }

        public void RozladujKontener(string numerSeryjny)
        {
            var kontener = kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener != null)
            {
                kontener.Oproznij();
            }
        }

        public void ZamienKontener(string numerSeryjny, Kontener nowy)
        {
            int index = kontenery.FindIndex(k => k.NumerSeryjny == numerSeryjny);
            if (index != -1)
            {
                kontenery[index] = nowy;
                Console.WriteLine($"Zamieniono kontener {numerSeryjny} na nowy {nowy.NumerSeryjny}.");
            }
        }

        public void WypiszKontenery()
        {
            Console.WriteLine($"--- Kontenerowiec {Nazwa} ---");
            foreach (var kontener in kontenery)
            {
                Console.WriteLine(kontener);
            }
        }

        public bool PrzeniesKontenerDo(Kontenerowiec innyStatek, string numerSeryjny)
        {
            var kontener = kontenery.FirstOrDefault(k => k.NumerSeryjny == numerSeryjny);
            if (kontener == null) return false;

            try
            {
                innyStatek.ZaladujKontener(kontener);
                kontenery.Remove(kontener);
                Console.WriteLine(
                    $"Przeniesiono kontener {numerSeryjny} ze statku {Nazwa} na statek {innyStatek.Nazwa}.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas przenoszenia: {ex.Message}");
                return false;
            }
        }

        public String AktualnaWaga()
        {
            return $"Kontener: {Nazwa} | Aktualna waga: {kontenery.Sum(k => k.MasaLadunku)}";
        }

        public String LiczbaKontenerow()
        {
            return $"Kontener: {Nazwa} | Liczba kontenerów: {kontenery.Count}";
        }

        public override string ToString()
        {
            return $"Kontenerowiec : | nazwa: {Nazwa} | maxPredkość: {MaksPredkosc} | maxŁadowność: {MaksLadownoscWTonach} | maxKontenerów: {MaksLiczbaKontenerow}";
        }
    }
}
