using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Repository
{
    public class ReChiTietDon : IChiTietDon
    {
        public readonly DoanContext _context;
        public ReChiTietDon(DoanContext context)
        {
            _context = context;
        }
        public bool Add(CreateCTD crCTD)
        {
            
            foreach (int id in crCTD.Ctghid)
            {
                Ctgh ctgh = _context.Ctghs.FirstOrDefault(c => c.Id == id);
                Chitietdon ctd = new Chitietdon
                {
                    
                    DonhangId = crCTD.Donhangid,
                    TaikhoanId = ctgh.TaikhoanId,
                    Soluong = ctgh.Soluong,
                    SanphamId = ctgh.SanphamId,
                    Dongia = _context.Sanphams.FirstOrDefault(s => s.Id == ctgh.SanphamId).Dongia
                };
                _context.Add(ctd);
            }
            return Save();
        }

        public bool Delete(Chitietdon ctd)
        {
            _context.Remove(ctd);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Chitietdon ctd)
        {
            _context.Update(ctd);
            return Save();

        }
    }
}
