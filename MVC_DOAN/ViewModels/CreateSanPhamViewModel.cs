namespace MVC_DOAN.ViewModels
{
    public class CreateSanPhamViewModel
    {
        
        public int Id { get; set; }

        public int LoaisanphamId { get; set; }

        public string? Tensp { get; set; }

        public int? Dongia { get; set; }

        public int? Soluongdaban { get; set; }

        public int? Soluongtonkho { get; set; }

        public string? Tinhtrang { get; set; }

        public IFormFile? Img { get; set; }
        public string TaikhoanId { get; set; }
    }
}
