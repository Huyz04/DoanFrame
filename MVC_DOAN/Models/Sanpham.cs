using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Sanpham
{
    public string Masp { get; set; } = null!;

    public string? Malsp { get; set; }

    public string? Tensp { get; set; }

    public int? Dongia { get; set; }

    public int? Soluongdaban { get; set; }

    public int? Soluongtonkho { get; set; }

    public string? Tinhtrang { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<Chitietdon> Chitietdons { get; set; } = new List<Chitietdon>();

    public virtual ICollection<Ctgh> Ctghs { get; set; } = new List<Ctgh>();

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();

    public virtual Loaisanpham? MalspNavigation { get; set; }
}
