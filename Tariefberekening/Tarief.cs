namespace Tariefberekening;

/// <summary>
/// Berekent het ritprijs-tarief op basis van de leeftijd van de reiziger.
/// We zetten de logica in een aparte klasse zodat we ze kunnen testen,
/// los van Console.ReadLine/WriteLine.
/// </summary>
public static class Tarief
{
    /// <summary>
    /// Geeft het tarief in euro terug op basis van de leeftijd.
    /// Bij een onbekende leeftijd (null) geldt het volle tarief.
    /// </summary>
    public static decimal Bereken(int? leeftijd) => leeftijd switch
    {
        null => 2.50m,
        < 0 => throw new ArgumentOutOfRangeException(
            nameof(leeftijd), "Leeftijd kan niet negatief zijn."),
        < 6 => 0.00m,   // jonge kinderen reizen gratis
        <= 25 => 1.50m, // jongerentarief
        < 65 => 2.50m,  // vol tarief
        _ => 1.00m,     // seniorentarief vanaf 65
    };
}
