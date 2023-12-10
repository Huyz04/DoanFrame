using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_DOAN.Models;

public partial class Loaisanpham
{
    [Key]
    public int Id { get; set; }

    public string? Tenlsp { get; set; }

    public string? Tinhtrang { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }

}
