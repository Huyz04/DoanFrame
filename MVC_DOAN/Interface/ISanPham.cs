using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface ISanPham
    {
        Task<SanPhamVM> GetAll();
        Task<Sanpham> GetByIdAsync(int Id);
        Task<Sanpham> GetByIdAsyncNoTracking(int Id);
        Task<SanPhamVM> GetFilter (string timkiem, int MaLSP, string sapxep, int giaduoi, int giatren);

		bool Add(Sanpham SP);
        bool Update(Sanpham SP);
        bool Delete(Sanpham SP);
        bool Save();
    }
}
