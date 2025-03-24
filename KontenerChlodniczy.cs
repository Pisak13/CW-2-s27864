namespace CW_2_s27864
{
    public class KontenerChlodniczy : Kontener, IHazardNotifier
    {
        public string Produkt { get; private set; }
        public double Temperatura { get; private set; }

        
        private static readonly Dictionary<string, double> WymaganeTemperatury = new()
        {
            { "Bananas", 13.3 },
            { "Chocolate", 18 },
            { "Fish", 2 },
            { "Meat", -15 },
            { "Ice cream", -18 },
            { "Frozen pizza", -30 },
            { "Cheese", 7.2 },
            { "Sausages", 5 },
            { "Butter", 20.5 },
            { "Eggs", 19 }
        };

        public KontenerChlodniczy(
            string produkt,
            double temperatura,
            double wysokosc,
            double wagaWlasna,
            double glebokosc,
            double maksLadownosc)
            : base("C", wysokosc, wagaWlasna, glebokosc, maksLadownosc)
        {
            if (!WymaganeTemperatury.ContainsKey(produkt))
            {
                throw new ArgumentException($"Produkt '{produkt}' nie jest obsługiwany.");
            }

            double wymaganaTemp = WymaganeTemperatury[produkt];

            if (temperatura < wymaganaTemp)
            {
                NotifyHazard($"Zbyt niska temperatura dla produktu '{produkt}'! Wymagana: {wymaganaTemp}°C", NumerSeryjny);
                throw new InvalidOperationException($"Temperatura {temperatura}°C jest za niska dla produktu '{produkt}' (wymagana: {wymaganaTemp}°C).");
            }

            Produkt = produkt;
            Temperatura = temperatura;
        }

        public override void Zaladuj(double masa)
        {
            if (masa > MaksLadownosc)
            {
                NotifyHazard("Próba przeładowania kontenera chłodniczego!", NumerSeryjny);
                throw new OverfillException("Przekroczono maksymalną ładowność kontenera chłodniczego.");
            }

            MasaLadunku = masa;
        }

        public override void Oproznij()
        {
            MasaLadunku = 0;
            Console.WriteLine($"Kontener {NumerSeryjny} opróżniony.");
        }

        public void NotifyHazard(string message, string containerNumber)
        {
            Console.WriteLine($"[HAZARD] {message} | Kontener: {containerNumber}");
        }

        public override string ToString()
        {
            return $"[{NumerSeryjny}] Chłodniczy | Produkt: {Produkt} | Temp: {Temperatura}°C | Masa: {MasaLadunku}/{MaksLadownosc} kg";
        }
    }
}
