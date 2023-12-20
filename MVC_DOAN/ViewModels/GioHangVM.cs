using MVC_DOAN.Models;

namespace MVC_DOAN.ViewModels
{
    public class GioHangVM
    {
        public IEnumerable<Diachi> diachis { get; set; }
        public IEnumerable<CtghVM> ctghvms { get; set; }
    }
}
