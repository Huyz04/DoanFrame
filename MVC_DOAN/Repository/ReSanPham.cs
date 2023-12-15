using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

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

        public async Task<SanPhamVM> GetAll()
        {
            var sanphamVM = new SanPhamVM();
            sanphamVM.sanphamVM = await _context.Sanphams.ToListAsync();
            sanphamVM.loaisanphamVM = await _context.Loaisanphams.ToListAsync();

            return sanphamVM;
        }

        public async Task<Sanpham> GetByIdAsync(int Id)
        {
            return await _context.Sanphams.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Sanpham> GetByIdAsyncNoTracking(int Id)
        {
            return await _context.Sanphams.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }


		public async Task<SanPhamVM> GetFilter(string timkiem, int MaLSP, string sapxep, int giaduoi, int giatren)
		{
			var sanphamVM = new SanPhamVM();
			sanphamVM.loaisanphamVM = await _context.Loaisanphams.ToListAsync();
			// Xây dựng truy vấn dựa trên các tiêu chí tìm kiếm
			var query = _context.Sanphams.AsQueryable();

			// Lọc theo từ khóa tìm kiếm
			if (!string.IsNullOrEmpty(timkiem))
			{
				query = query.Where(s => s.Tensp.Contains(timkiem));
			}

			// Lọc theo mã loại sản phẩm
			if (MaLSP != 0)
			{
				query = query.Where(s => s.LoaisanphamId == MaLSP);
			}

			// Lọc theo mức giá
			query = query.Where(s => s.Dongia >= giaduoi && s.Dongia <= giatren);

			// Sắp xếp theo giá
			if (sapxep == "ASC")
			{
				query = query.OrderBy(s => s.Dongia);
			}
			else if (sapxep == "DESC")
			{
				query = query.OrderByDescending(s => s.Dongia);
			}

			// Lấy danh sách sản phẩm từ truy vấn
			sanphamVM.sanphamVM = await query.ToListAsync();

			return sanphamVM;

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
