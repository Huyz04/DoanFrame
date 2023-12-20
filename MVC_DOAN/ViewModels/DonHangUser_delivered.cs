using MVC_DOAN.Models;

namespace MVC_DOAN.ViewModels
{
    public class DonHangUser_delivered
    {
        public Donhang donhang { get; set; }
        public Diachi diachi { get; set; }

        public IEnumerable<Chitietdon> chitietdons { get; set; }
    }
}
