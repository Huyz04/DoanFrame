using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Repository
{
    public class ReUser : IUser
    {
        private readonly DoanContext _context;

        public ReUser(DoanContext context)
        {
            _context = context;
        }
        public bool Add(Taikhoan taikhoan)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Taikhoan taikhoan)
        {
            throw new NotImplementedException();
        }

		public async Task<IEnumerable<Taikhoan>> GetAllTaikhoan()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<DiaChiVM> GetDiachibyId(string Id,string name, string mail)
        {
            var DCVM = new DiaChiVM();
            DCVM.name = name;
            DCVM.mail = mail;

            DCVM.diachi = await _context.Diachis.Where(c => c.TaikhoanId == Id).ToListAsync();
            return DCVM;
        }

        public async Task<DonHangUser> GetDonHangUsersByTaiKhoanID(string taiKhoanID,string name, string mail)
        {
            var DONHANGUSER = new DonHangUser();
            DONHANGUSER.name = name;
            DONHANGUSER.email = mail;
            var donHang_NotAP = new List<DonHangUser_notApproved>();

            var donhangs = await _context.Donhangs.Where(c => c.TaikhoanId == taiKhoanID && c.Trangthaidonhang == "Chờ duyệt").ToListAsync();

            foreach (var donhangg in donhangs)
            {
                var donHangUser = new DonHangUser_notApproved
                {
                    donhang = donhangg,
                    diachi = await _context.Diachis.FirstOrDefaultAsync(c => c.Id == donhangg.DiachiId),
                    
                    
                    chitietdons = await _context.Chitietdons.Where(c => c.DonhangId == donhangg.Id).Include(c=>c.sanpham).ToListAsync()
                      
                };

                donHang_NotAP.Add(donHangUser);
            }


            DONHANGUSER.dh_notAp = donHang_NotAP;

            var donHang_AP = new List<DonHangUser_approved>();

            var donhangs_ap = await _context.Donhangs.Where(c => c.TaikhoanId == taiKhoanID && c.Trangthaidonhang == "Đã duyệt").ToListAsync();

            foreach (var donhang in donhangs_ap)
            {
                var donHangUser = new DonHangUser_approved
                {
                    donhang = donhang,
                    diachi = await _context.Diachis.FirstOrDefaultAsync(c => c.Id == donhang.DiachiId),

                    chitietdons = await _context.Chitietdons.Where(c => c.DonhangId == donhang.Id).ToListAsync()
                };

                donHang_AP.Add(donHangUser);
            }


            DONHANGUSER.dh_ap = donHang_AP;


            var donHang_de = new List<DonHangUser_delivering>();

            var donhangs_de = await _context.Donhangs.Where(c => c.TaikhoanId == taiKhoanID && c.Trangthaidonhang == "Đang vận chuyển").ToListAsync();

            foreach (var donhang in donhangs_de)
            {
                var donHangUser = new DonHangUser_delivering
                {
                    donhang = donhang,
                    diachi = await _context.Diachis.FirstOrDefaultAsync(c => c.Id == donhang.DiachiId),

                    chitietdons = await _context.Chitietdons.Where(c => c.DonhangId == donhang.Id).ToListAsync()
                };

                donHang_de.Add(donHangUser);
            }


            DONHANGUSER.dh_de = donHang_de;


            var donHang_ed = new List<DonHangUser_delivered>();

            var donhangs_ed = await _context.Donhangs.Where(c => c.TaikhoanId == taiKhoanID && c.Trangthaidonhang == "Đã giao").ToListAsync();

            foreach (var donhang in donhangs_ed)
            {
                var donHangUser = new DonHangUser_delivered
                {
                    donhang = donhang,
                    diachi = await _context.Diachis.FirstOrDefaultAsync(c => c.Id == donhang.DiachiId),
                    chitietdons = await _context.Chitietdons.Where(c => c.DonhangId == donhang.Id).ToListAsync()
                };

                donHang_ed.Add(donHangUser);
            }


            DONHANGUSER.dh_ed = donHang_ed;


            return DONHANGUSER;
        }

        public async Task<Taikhoan> GetTaikhoanbyId(string Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Taikhoan taikhoan)
        {
            _context.Update(taikhoan);
            return Save();
        }
    }
}
