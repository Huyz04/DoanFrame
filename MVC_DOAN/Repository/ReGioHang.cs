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
			giohangVM.ctghvms = await _context.Ctghs
		 .Where(c => c.TaikhoanId == Id)
		 .Join(
			 _context.Sanphams,
			 ctgh => ctgh.SanphamId,
			 sanpham => sanpham.Id,
			 (ctgh, sanpham) => new CtghVM
			 {
				 Id = ctgh.Id,
				 Soluong = ctgh.Soluong,
				 SanphamId = ctgh.SanphamId,
				 TaikhoanId = ctgh.TaikhoanId,
				 Tensp = sanpham.Tensp,
				 Dongia = sanpham.Dongia,
				 Img = sanpham.Img
			 }
		 )
		 .ToListAsync();
			giohangVM.diachis = await _context.Diachis.Where(d => d.TaikhoanId == Id).ToListAsync();
			return giohangVM;
        }

        public async Task<Ctgh> GetCtghById(int Id)
        {
            return await _context.Ctghs.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Ctgh Check(Ctgh ctgh)
        {
            var check =  _context.Ctghs.FirstOrDefault(c => c.SanphamId == ctgh.SanphamId && c.TaikhoanId == ctgh.TaikhoanId);
            if (check != null)
            {
                return check;
            }
            else
            {
                return null;
            }
        }
    }
}
