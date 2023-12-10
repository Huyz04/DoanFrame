using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Chitietdon
{
    [Key]
    public int Madon { get; set; }

    public int? Soluong { get; set; }

    public int? Dongia { get; set; }
    [ForeignKey("Sanpham")]
    public int? SanphamId { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }

}
