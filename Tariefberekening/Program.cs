using Tariefberekening;

Console.Write("Wat is je leeftijd? ");
string? invoer = Console.ReadLine();

// int.TryParse geeft false terug bij lege of ongeldige invoer.
// In dat geval blijft de leeftijd onbekend (null) en geldt het volle tarief.
int? leeftijd = int.TryParse(invoer, out int gelezen) ? gelezen : null;

// De eigenlijke logica zit in een aparte, testbare method.
decimal prijs = Tarief.Bereken(leeftijd);

Console.WriteLine($"Jouw tarief: {prijs:C2}");
