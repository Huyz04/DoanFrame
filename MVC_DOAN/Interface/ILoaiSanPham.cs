using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Interface
{
    public interface ILoaiSanPham
    {
        Task<IEnumerable<Loaisanpham>> GetAll();
        Task<IEnumerable<Loaisanpham>> GetTinhtrang();
        Task<IEnumerable<Loaisanpham>> Edit(EditLSP EDLSP);

        Task<Loaisanpham> GetById(int Id);
        Task<Loaisanpham> GetByIdNoTracking(int Id);

        bool Add(Loaisanpham LSP);
        bool Update(Loaisanpham LSP);
        bool Delete(Loaisanpham LSP);
        bool Save();

    }
}
