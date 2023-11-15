using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Diachi
{
    public string Madc { get; set; } = null!;

    public string? Matk { get; set; }

    public string? Hotennguoinhan { get; set; }

    public string? Sdt { get; set; }

    public string? Tinh { get; set; }

    public string? Huyen { get; set; }

    public string? Diachichitiet { get; set; }

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();
}
