using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Donhang
{
    [Key]
    public int Id { get; set; }
    public int? Tongtien { get; set; }

    public DateTime Ngaytao { get; set; }

    public DateTime? Ngaygiao { get; set; }

    public string? Phuongthucthanhtoan { get; set; }

    public string? Trangthaithanhtoan { get; set; }

    public string? Trangthaidonhang { get; set; }

    [ForeignKey("Diachi")]
    public int? DiachiId { get; set; }
    public Diachi? Diachi { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }
}
