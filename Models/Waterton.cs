using System;
using System.Collections.Generic;

namespace AquaBrainAPI;
public partial class requestWaterton {
    public int WoningId { get; set; }
    public string Naam { get; set; } = null!;
    public int MaxInhoud { get; set; }
}
public partial class Waterton
{
    public int Id { get; set; }

    public int WoningId { get; set; }

    public string Naam { get; set; } = null!;

    /// <summary>
    /// L
    /// </summary>
    public int MaxInhoud { get; set; }

    /// <summary>
    /// Huidige Inhoud
    /// </summary>
    public int? Inhoud { get; set; }

    public DateTime? LaatsteOnderhoud { get; set; }

    public DateTime? VolgendeOnderhoud { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<OnderhoudLogboek> OnderhoudLogboeks { get; set; } = new List<OnderhoudLogboek>();

    public virtual ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();

    public virtual ICollection<Valve> Valves { get; set; } = new List<Valve>();

    public virtual Woning Woning { get; set; } = null!;
}
