using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Repository
{
    public class ReDonHang : IDonHang
    {
        public readonly DoanContext _context;
        public ReDonHang(DoanContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Donhang donhang)
        {
            _context.Add(donhang);
            await _context.SaveChangesAsync();
            return donhang.Id;
        }

        public bool Delete(Donhang donhang)
        {
            _context.Remove(donhang);
            return Save();
        }

        public async Task<Ctgh> GetCtghById(int Id)
        {
                return await _context.Ctghs.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Donhang donhang)
        {
            _context.Update(donhang);
            return Save();
        }

        async Task<Donhang> IDonHang.GetDonHangById(int Id)
        {
            return await _context.Donhangs.FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
