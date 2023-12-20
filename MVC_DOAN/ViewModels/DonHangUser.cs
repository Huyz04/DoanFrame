namespace MVC_DOAN.ViewModels
{
    public class DonHangUser
    {
        public string? email { get; set; }
        public string? name { get; set; }
        public IEnumerable<DonHangUser_notApproved>  dh_notAp { get; set; }
        public IEnumerable<DonHangUser_approved> dh_ap { get; set; }
        public IEnumerable<DonHangUser_delivering> dh_de { get; set; }
        public IEnumerable<DonHangUser_delivered> dh_ed { get; set; }
    }
}
