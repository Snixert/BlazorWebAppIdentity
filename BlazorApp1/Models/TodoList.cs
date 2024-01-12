using System;
using System.Collections.Generic;

namespace BlazorApp1.Models;

public partial class TodoList
{
    public int Id { get; set; }

    public string User { get; set; } = null!;

    public string Name { get; set; } = null!;
}
