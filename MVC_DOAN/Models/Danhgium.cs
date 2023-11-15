using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Danhgium
{

    public string Madg { get; set; } = null!;

    public string? Masp { get; set; }

    public string? Matk { get; set; }

    public string? Danhgiaa { get; set; }

    public int? Rate { get; set; }

    public virtual Sanpham? MaspNavigation { get; set; }

    public virtual Taikhoan? MatkNavigation { get; set; }
}
