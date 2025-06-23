using System;
using System.Collections.Generic;

namespace variant4.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Vin { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly PublicationDate { get; set; }

    public string State { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
