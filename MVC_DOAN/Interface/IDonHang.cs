using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface IDonHang
    {
        Task<Donhang> GetDonHangById(int Id);
        Task<Ctgh> GetCtghById(int Id);
        
        Task<int> Add(Donhang donhang);
        bool Update(Donhang donhang);
        bool Delete(Donhang donhang);
        bool Save();
    }
}
