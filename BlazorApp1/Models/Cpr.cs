using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class Cpr
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string CprNumber { get; set; } = null!;
}
