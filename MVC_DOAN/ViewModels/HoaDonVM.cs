using MVC_DOAN.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.ViewModels
{
	public class HoaDonVM
	{
		public int Id { get; set; }
		public int? Tongtien { get; set; }

		public DateTime Ngaytao { get; set; }

		public DateTime? Ngaygiao { get; set; }

		public string? Phuongthucthanhtoan { get; set; }

		public string? Trangthaithanhtoan { get; set; }

		public string? Trangthaidonhang { get; set; }

		public string? TaikhoanId { get; set; }
		public string? Emailnguoidung { get; set; }
	}
}
