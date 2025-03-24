

namespace CW_2_s27864;

public abstract class Kontener
{
    private static int globalCounter = 0;

    public string NumerSeryjny { get; private set; }
    public int Id { get; } = ++globalCounter;

    public double MasaLadunku { get; protected set; }
    public double Wysokosc { get; }
    public double WagaWlasna { get; }
    public double Glebokosc { get; }
    public double MaksLadownosc { get; }

    protected Kontener(string typ, double wysokosc, double wagaWlasna, double glebokosc, double maksLadownosc)
    {
        Wysokosc = wysokosc;
        WagaWlasna = wagaWlasna;
        Glebokosc = glebokosc;
        MaksLadownosc = maksLadownosc;

        NumerSeryjny = $"KON-{typ}-{Id}";
    }

    public abstract void Zaladuj(double masa);

    public abstract void Oproznij();
    

    public override string ToString()
    {
        return $"Kontener {NumerSeryjny} | Masa: {MasaLadunku}kg / {MaksLadownosc}kg";
    }
}
