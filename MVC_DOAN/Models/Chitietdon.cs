using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Chitietdon
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("Donhang")]
    public int? DonhangId { get; set; }
    public Donhang? Donhang { get; set; }

    public int? Soluong { get; set; }

    public int? Dongia { get; set; }

    [ForeignKey("Sanpham")]
    public int? SanphamId { get; set; }
    public Sanpham sanpham { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }

}
