using System;
using System.Collections.Generic;

namespace AquaBrainAPI;

public partial class Woning
{
    public int Id { get; set; }

    public int KlantId { get; set; }

    public string Naam { get; set; } = null!;

    public string? Adres { get; set; }

    public string? Postcode { get; set; }

    public string? Plaats { get; set; }

    public string? Land { get; set; }

    /// <summary>
    /// M3
    /// </summary>
    public int? Oppervlakte { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual Klant Klant { get; set; } = null!;

    public virtual ICollection<Waterton> Watertons { get; set; } = new List<Waterton>();
}
