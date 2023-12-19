using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface IGioHang
    {
        Task<GioHangVM> GetGioHangById(string Id);
        Task<Ctgh> GetCtghById(int Id);
        Ctgh Check(Ctgh ctgh);
        bool Add(Ctgh ctgh);
        bool Update(Ctgh ctgh);
        bool Delete(Ctgh ctgh);
        bool Save();
    }
}
