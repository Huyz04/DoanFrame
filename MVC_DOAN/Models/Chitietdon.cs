using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Chitietdon
{
    public string Madon { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public int? Soluong { get; set; }

    public int? Dongia { get; set; }

    public virtual Donhang MadonNavigation { get; set; } = null!;

    public virtual Sanpham MaspNavigation { get; set; } = null!;

}
