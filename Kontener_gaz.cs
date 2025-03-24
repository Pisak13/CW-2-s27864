

namespace CW_2_s27864
{
    public class KontenerNaGaz : Kontener, IHazardNotifier
    {
        public double Cisnienie { get; }

        public KontenerNaGaz(
            double wysokosc,
            double wagaWlasna,
            double glebokosc,
            double maksLadownosc,
            double cisnienie)
            : base("G", wysokosc, wagaWlasna, glebokosc, maksLadownosc)
        {
            Cisnienie = cisnienie;
        }

        public override void Zaladuj(double masa)
        {
            if (masa > MaksLadownosc)
            {
                NotifyHazard("Próba przeładowania kontenera na gaz!", NumerSeryjny);
                throw new OverfillException($"Załadunek przekracza maksymalną ładowność ({MaksLadownosc} kg) kontenera {NumerSeryjny}.");
            }

            MasaLadunku = masa;
        }

        
        
        public override void Oproznij()
        {
            double pozostalo = MasaLadunku * 0.05;
            MasaLadunku = pozostalo;

            Console.WriteLine($"Kontener {NumerSeryjny} opróżniony (pozostawiono 5% gazu: {pozostalo:F2} kg).");
        }

        public void NotifyHazard(string message, string containerNumber)
        {
            Console.WriteLine($"[HAZARD] {message} | Kontener: {containerNumber}");
        }

        public override string ToString()
        {
            return $"[{NumerSeryjny}] Gazowy | Masa ładunku: {MasaLadunku} kg / {MaksLadownosc} kg | " +
                   $"Wysokość: {Wysokosc} cm | Głębokość: {Glebokosc} cm | Ciśnienie: {Cisnienie} atm";
        }
    }
}