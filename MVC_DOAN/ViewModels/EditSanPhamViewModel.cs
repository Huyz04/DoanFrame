namespace MVC_DOAN.ViewModels
{
    public class EditSanPhamViewModel
    {
        public string Masp { get; set; } 

        public string? Malsp { get; set; }

        public string? Tensp { get; set; }

        public int? Dongia { get; set; }

        public int? Soluongdaban { get; set; }

        public int? Soluongtonkho { get; set; }

        public string? Tinhtrang { get; set; }

        public IFormFile? Img { get; set; }
        public string? URL { get; set; }

    }
}
