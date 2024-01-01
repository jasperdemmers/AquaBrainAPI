using System;
using System.Collections.Generic;

namespace AquaBrainAPI;

public partial class requestKlant {
    public string Gebruikersnaam { get; set; } = null!;
    public string Wachtwoord { get; set; } = null!;
    public string Voornaam { get; set; } = null!;
    public string Achternaam { get; set; } = null!;
    public string Type { get; set; } = "Particulier";
    public string Email { get; set; } = null!;
    public string Telefoon { get; set; } = null!;
    public DateOnly GeboorteDatum { get; set; }

}
public partial class Klant
{
    public int? Id { get; set; } = null!;

    public string Gebruikersnaam { get; set; } = null!;

    /// <summary>
    /// Plain text
    /// </summary>
    public string Wachtwoord { get; set; } = null!;

    public string Voornaam { get; set; } = null!;

    public string Achternaam { get; set; } = null!;

    /// <summary>
    /// Bedrijf, Particulier
    /// </summary>
    public string Type { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefoon { get; set; } = null!;

    public DateOnly GeboorteDatum { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<Woning> Wonings { get; set; } = new List<Woning>();
}
