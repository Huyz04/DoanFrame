using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Donhang
{

    public string Madon { get; set; } = null!;

    public string? Madc { get; set; }

    public int? Tongtien { get; set; }

    public DateTime? Ngaytao { get; set; }

    public DateTime? Ngaygiao { get; set; }

    public string? Phuongthucthanhtoan { get; set; }

    public string? Trangthaithanhtoan { get; set; }

    public string? Trangthaidonhang { get; set; }

    public virtual ICollection<Chitietdon> Chitietdons { get; set; } = new List<Chitietdon>();

    public virtual Diachi? MadcNavigation { get; set; }
}
