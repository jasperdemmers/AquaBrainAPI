using System;
using System.Collections.Generic;

namespace AquaBrainAPI;

public partial class OnderhoudLogboek
{
    public int Id { get; set; }

    public int WatertonId { get; set; }

    public string Notes { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

}
