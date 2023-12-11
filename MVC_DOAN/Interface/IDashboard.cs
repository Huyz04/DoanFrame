using MVC_DOAN.Models;

namespace MVC_DOAN.Interface
{
    public interface IDashboard
    {
        Task<List<Loaisanpham>> GetAllUserLoaiSanPham();
        Task<List<Sanpham>> GetAllUserSanPham();
        Task<Taikhoan> GetUserById(string Id);
    }
}
