using MVC_DOAN.Models;

namespace MVC_DOAN.ViewModels
{
    public class GioHangVM
    {
        public IEnumerable<Sanpham> sanphamVM { get; set; }
        public IEnumerable<Ctgh> ctghVM { get; set; }
    }
}
