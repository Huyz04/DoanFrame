using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;

namespace MVC_DOAN.Repository
{
    public class ReSanPham : ISanPham
    {
        public readonly DoanContext _context;
        public ReSanPham(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Sanpham SP)
        {
            _context.Add(SP);
            return Save();
        }

        public bool Delete(Sanpham SP)
        {
            _context.Remove(SP);
            return Save();
        }

        public async Task<IEnumerable<Sanpham>> GetAll()
        {
            return await _context.Sanphams.ToListAsync();
        }

        public async Task<Sanpham> GetById(string Id)
        {
            return await _context.Sanphams.FirstOrDefaultAsync(c => c.Masp == Id);
        }

        public async Task<Sanpham> GetByIdNoTracking(string Id)
        {
            return await _context.Sanphams.AsNoTracking().FirstOrDefaultAsync(c => c.Masp == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Sanpham SP)
        {
            _context.Update(SP);
            return Save();
        }
    }
}
