using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Phiship
{
    [Key]
    public int Id { get; set; }
    public string? Tinh { get; set; }

    public string? Quan { get; set; }

    public int? Phi { get; set; }

    public int? Thoigian { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }
}
