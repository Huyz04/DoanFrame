using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Repository
{
    public class ReGioHang : IGioHang
    {
        private readonly DoanContext _context;

        public ReGioHang(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Ctgh ctgh)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Ctgh ctgh)
        {
            throw new NotImplementedException();
        }

        public async Task<GioHangVM> GetGioHangById(string Id)
        {
            var giohangVM = new GioHangVM();
            giohangVM.ctghVM = await _context.Ctghs.Where(c => c.TaikhoanId == Id).ToListAsync();
            var sanphamIds = giohangVM.ctghVM.Select(c => c.SanphamId).ToList();
            giohangVM.sanphamVM = await _context.Sanphams.Where(s => sanphamIds.Contains(s.Id)).ToListAsync();

            return giohangVM;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Ctgh ctgh)
        {
            throw new NotImplementedException();
        }
    }
}
