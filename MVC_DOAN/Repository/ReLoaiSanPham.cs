using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_DOAN.Repository
{
    public class ReLoaiSanPham : ILoaiSanPham
    {
        private readonly DoanContext _context;

        public ReLoaiSanPham(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Loaisanpham LSP)
        {
            _context.Add(LSP);
            return Save();
        }

        public bool Delete(Loaisanpham LSP)
        {
            _context.Remove(LSP);
            return Save();
        }

        public async Task<IEnumerable<Loaisanpham>> GetAll()
        {
            return await _context.Loaisanphams.ToListAsync();

            //_context.Loaisanphams.Where(c => c.Tinhtrang.Contains(xx)).TolistAsync();
        }

        public async Task<Loaisanpham> GetById(int Id)
        {
            return await _context.Loaisanphams.FirstOrDefaultAsync(c => c.Id == Id);
        }


        public async Task<Loaisanpham> GetByIdNoTracking(int Id)
        {
            return await _context.Loaisanphams.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<IEnumerable<Loaisanpham>> GetTinhtrang()
        {
            return await _context.Loaisanphams.Where(c => c.Tinhtrang == "1").ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Loaisanpham LSP)
        {
            _context.Update(LSP);
            return Save();
        }
    }
}
