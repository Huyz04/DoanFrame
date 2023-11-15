using MVC_DOAN.Models;

namespace MVC_DOAN.Interface
{
    public interface ILoaiSanPham
    {
        Task<IEnumerable<Loaisanpham>> GetAll();
        Task<Loaisanpham> GetById(string Id);
        Task<Loaisanpham> GetByIdNoTracking(string Id);

        bool Add(Loaisanpham LSP);
        bool Update(Loaisanpham LSP);
        bool Delete(Loaisanpham LSP);
        bool Save();

    }
}
