using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.Models;

public partial class Diachi
{
    [Key]
    public int Id { get; set; }

    public string? Hotennguoinhan { get; set; }

    public string? Sdt { get; set; }
    public string? Xa { get; set; }

    public string? Tinh { get; set; }

    public string? Huyen { get; set; }

    public string? Diachichitiet { get; set; }
    [ForeignKey("Taikhoan")]
    public string? TaikhoanId { get; set; }
    public Taikhoan? Taikhoan { get; set; }
    public string? Tinhtrang { get; set; }
}
