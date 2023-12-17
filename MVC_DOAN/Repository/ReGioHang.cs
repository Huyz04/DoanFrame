using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Repository
{
    public class ReGioHang : IGioHang
    {
        public readonly DoanContext _context;
        public ReGioHang(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Ctgh ctgh)
        {
            _context.Add(ctgh);
            return Save();
        }

        public bool Delete(Ctgh ctgh)
        {
            _context.Remove(ctgh);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Ctgh ctgh)
        {
            _context.Update(ctgh);
            return Save();
        }

        public async Task<GioHangVM> GetGioHangById(string Id)
        {
            var giohangVM = new GioHangVM();
            giohangVM.ctghs = await _context.Ctghs.Where(c => c.TaikhoanId == Id).ToListAsync();
            var sanphamIds = giohangVM.ctghs.Select(ctgh => ctgh.SanphamId).ToList();
            giohangVM.sanphams = await _context.Sanphams.Where(s => sanphamIds.Contains(s.Id)).ToListAsync();
            giohangVM.diachis = await _context.Diachis.Where(d => d.TaikhoanId == Id).ToListAsync();
            return giohangVM;
        }
    }
}
