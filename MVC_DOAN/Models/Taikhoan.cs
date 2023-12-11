using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_DOAN.Models;

public partial class Taikhoan : IdentityUser

{
    public string? Mail { get; set; }
    public string? Img { get; set; }
        
    public string? Matkhau { get; set; }

    public string? Phanloai { get; set; }

    public string? Nickname { get; set; }

    public virtual ICollection<Ctgh> Ctghs { get; set; }
    public virtual ICollection<Danhgia> Danhgias { get; set; }
    public virtual ICollection<Sanpham> Sanphams { get; set; }
    public virtual ICollection<Loaisanpham> Loaisanphams { get; set; }
    public virtual ICollection<Donhang> Donhangs  { get; set; }
    public virtual ICollection<Diachi> Diachi { get; set; }
    public virtual ICollection<Phiship> Phiships { get; set; }
    public virtual ICollection<Chitietdon> Chitietdons { get; set; }

}
