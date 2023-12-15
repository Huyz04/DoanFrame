using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Sanpham
{
    [Key]
    public int Id { get; set; }

    public string? Tensp { get; set; }

    public int? Dongia { get; set; }

    public int? Soluongdaban { get; set; }

    public int? Soluongtonkho { get; set; }

    public string? Tinhtrang { get; set; }
    public string? Mota { get; set; }

    public string? Img { get; set; }
    [ForeignKey("LoaiSanPham")]
    public int LoaisanphamId { get; set; }
    public Loaisanpham?  Loaisanpham { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }


}
