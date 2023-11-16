using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_DOAN.Models;

public partial class Taikhoan : IdentityUser    
{
    public string Matk { get; set; } = null!;

    public string? Email { get; set; }

    public string? Matkhau { get; set; }

    public string? Phanloai { get; set; }

    public string? Nickname { get; set; }

    public virtual ICollection<Ctgh> Ctghs { get; set; } = new List<Ctgh>();

    public virtual ICollection<Danhgium> Danhgia { get; set; } = new List<Danhgium>();
}
