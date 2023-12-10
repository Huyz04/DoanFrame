using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Danhgia
{
    [Key]
    public int Id { get; set; }

    public string? Danhgiaa { get; set; }

    public int? Rate { get; set; }
    [ForeignKey("Sanpham")]
    public int? SanphamId { get; set; }
    public Sanpham? Sanpham { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }
}
