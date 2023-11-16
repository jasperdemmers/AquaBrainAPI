using System;
using System.Collections.Generic;

namespace AquaBrainAPI;

public partial class requestValve {
    public bool Open { get; set; }
}

public partial class Valve
{
    public int Id { get; set; }

    public bool Open { get; set; }

    public int WatertonId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Waterton Waterton { get; set; } = null!;
}
