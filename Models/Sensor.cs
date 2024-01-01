using System;
using System.Collections.Generic;

namespace AquaBrainAPI;
public partial class newSensor
{
    public int WatertonId { get; set; }
    public int SensorID { get; set; }
    public int waarde { get; set; }
    public string Type { get; set; } = "waterniveau";
}
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
}
