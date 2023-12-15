using MVC_DOAN.Models;

namespace MVC_DOAN.ViewModels
{
    public class SanPhamVM
    {
        public IEnumerable<Sanpham> sanphamVM { get; set; }
        public IEnumerable<Loaisanpham> loaisanphamVM { get; set; }
    }
}
