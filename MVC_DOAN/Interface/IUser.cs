using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface IUser
    {
        Task<IEnumerable<Taikhoan>> GetAllTaikhoan();
        Task<Taikhoan> GetTaikhoanbyId(string Id);
        Task<DiaChiVM> GetDiachibyId(string Id,string name, string mail);

        Task<DonHangUser> GetDonHangUsersByTaiKhoanID(string Id,string name, string mail);
        bool Add(Taikhoan taikhoan);
        bool Update(Taikhoan taikhoan);
        bool Delete(Taikhoan taikhoan);
        bool Save();

    }
}
