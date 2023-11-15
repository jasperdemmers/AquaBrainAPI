using System;
using System.Collections.Generic;

namespace AquaBrainAPI;

public partial class Sensor
{
    public int Id { get; set; }

    public int WatertonId { get; set; }

    public int SensorId { get; set; }

    /// <summary>
    /// waterniveau
    /// waterverbruik
    /// waterkwaliteit
    /// </summary>
    public string Type { get; set; } = null!;

    public int Waarde { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Waterton Waterton { get; set; } = null!;
}
