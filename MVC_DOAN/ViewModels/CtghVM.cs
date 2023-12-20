using MVC_DOAN.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOAN.ViewModels
{
	public class CtghVM
	{
		public int Id { get; set; }

		public int? Soluong { get; set; }
		
		public int? SanphamId { get; set; }
		
		public string? TaikhoanId { get; set; }
		
		public string? Tensp { get; set; }
		public int? Dongia { get; set; }
		public string? Img { get; set; }
	}
}
