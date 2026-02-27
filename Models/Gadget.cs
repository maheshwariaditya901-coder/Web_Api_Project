using System;
using System.Collections.Generic;

namespace Web_Api_Project.Models;

public partial class Gadget
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}
