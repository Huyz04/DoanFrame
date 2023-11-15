using MVC_DOAN.Models;

namespace MVC_DOAN.Interface
{
    public interface ISanPham
    {
        Task<IEnumerable<Sanpham>> GetAll();
        Task<Sanpham> GetById(string Id);
        Task<Sanpham> GetByIdNoTracking(string Id);

        bool Add(Sanpham SP);
        bool Update(Sanpham SP);
        bool Delete(Sanpham SP);
        bool Save();
    }
}
