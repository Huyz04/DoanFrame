using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_DOAN.Models;

public partial class Phiship
{
    public string Maphi { get; set; } = null!;
    public string? Tinh { get; set; }

    public string? Quan { get; set; }

    public int? Phi { get; set; }

    public int? Thoigian { get; set; }
}
