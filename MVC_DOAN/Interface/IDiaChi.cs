using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface IDiaChi
    {
        Task<Diachi> GetGioHangById(string Id);
        bool Add(Diachi diachi);
        bool Update(Diachi diachi);
        bool Delete(Diachi diachi);
        bool Save();
    }
}
