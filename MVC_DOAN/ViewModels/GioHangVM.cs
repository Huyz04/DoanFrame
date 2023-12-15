using MVC_DOAN.Models;

namespace MVC_DOAN.ViewModels
{
    public class GioHangVM
    {
        public IEnumerable<Sanpham> sanphams { get; set; }
        public IEnumerable<Ctgh> ctghs { get; set; }
        public IEnumerable<Diachi> diachis { get; set; }
    }
}
