using CW_2_s27864;


public class KontenerPlyny : Kontener,IHazardNotifier
{
    public bool CzyLadunekNiebezpieczny { get; }

    public KontenerPlyny(double wysokosc, double wagaWlasna, double glebokosc, double maksLadownosc, bool czyLadunekNiebezpieczny)
        : base("L", wysokosc, wagaWlasna, glebokosc, maksLadownosc)
    {
        CzyLadunekNiebezpieczny = czyLadunekNiebezpieczny;
    }

    public override void Zaladuj(double masa)
    {
        double limit = CzyLadunekNiebezpieczny ? 0.5 : 0.9;

        if (masa > MaksLadownosc * limit)
        {
            NotifyHazard("Próba przeładowania kontenera z ładunkiem " +
                         (CzyLadunekNiebezpieczny ? "niebezpiecznym" : "zwykłym"), NumerSeryjny);
            throw new OverfillException("Za duży ładunek!");
        }

        MasaLadunku = masa;
    }

    public void NotifyHazard(string message, string containerNumber)
    {
        Console.WriteLine($"[Hazard] {message} | Kontener: {containerNumber}");
    }

    public override void Oproznij()
    {
        MasaLadunku = 0;
        Console.WriteLine($"Kontener opróżniony. Numer: {NumerSeryjny}");
    }

    public override string ToString()
    {
        return $"[{NumerSeryjny}] Masa ładunku: {MasaLadunku} kg, Wysokość: {Wysokosc} cm, " +
               $"Waga własna: {WagaWlasna} kg, Głębokość: {Glebokosc} cm, Max: {MaksLadownosc} kg";
    }
}
