using MVC_DOAN.Models;

namespace MVC_DOAN.Interface
{
    public interface IUser
    {
        Task<IEnumerable<Taikhoan>> GetAllTaikhoan();
        Task<Taikhoan> GetTaikhoanbyId(string Id);
        bool Add(Taikhoan taikhoan);
        bool Update(Taikhoan taikhoan);
        bool Delete(Taikhoan taikhoan);
        bool Save();

    }
}
