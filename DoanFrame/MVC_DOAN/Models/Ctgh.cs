using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Ctgh
{ 

    public string Matk { get; set; } = null!;

    public string Masp { get; set; } = null!;

    public int? Soluong { get; set; }

    public virtual Sanpham MaspNavigation { get; set; } = null!;

    public virtual Taikhoan MatkNavigation { get; set; } = null!;

}
