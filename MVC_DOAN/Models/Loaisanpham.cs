using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_DOAN.Models;

public partial class Loaisanpham
{
    public string Malsp { get; set; } = null!;

    public string? Tenlsp { get; set; }

    public string? Tinhtrang { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
