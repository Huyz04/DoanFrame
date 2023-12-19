using MVC_DOAN.Models;

namespace MVC_DOAN.ViewModels
{
    public class DonHangUser
    {
        public IEnumerable<Donhang> donhangs {get;set;}
        public IEnumerable<Chitietdon> chitietdons { get; set; }

    }
}
