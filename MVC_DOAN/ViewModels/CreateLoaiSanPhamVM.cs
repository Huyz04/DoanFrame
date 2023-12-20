using MVC_DOAN.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.ViewModels
{
    public class CreateLoaiSanPhamVM
    {
        public int Id { get; set; }

        public string? Tenlsp { get; set; }

        public string? Tinhtrang { get; set; }
        public string? TaikhoanId { get; set; }
        public string? Motaa { get; set; }
    }
}
