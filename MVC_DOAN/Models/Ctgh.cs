using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Ctgh
{
    [Key]
    public int Id { get; set; }

    public int? Soluong { get; set; }
    [ForeignKey("Sanpham")]
    public int? SanphamId { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }
}
