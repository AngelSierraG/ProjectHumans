using System;
using System.Collections.Generic;

namespace ProjectHumans.Models;

public partial class Human
{
    public short Id { get; set; }

    public string? Name { get; set; }

    public string? Sex { get; set; }

    public string? Age { get; set; }

    public string? Height { get; set; }

    public string? Weight { get; set; }
}
