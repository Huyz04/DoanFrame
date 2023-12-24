using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.ViewModels;

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
        public async Task<IEnumerable<Loaisanpham>> Edit(EditLSP EDLSP)
        {
            var loaisanpham = await _context.Loaisanphams.FirstOrDefaultAsync(lsp => lsp.Id == EDLSP.Id);

            if (loaisanpham != null)
            {
                // Cập nhật các thuộc tính của Loại Sản phẩm
                loaisanpham.Tenlsp = EDLSP.Tenlsp;
                loaisanpham.Tinhtrang = EDLSP.Tinhtrang;
                loaisanpham.Mota = EDLSP.Mota;

                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                return await _context.Loaisanphams.ToListAsync();
                // Trả về Loại Sản phẩm sau khi chỉnh sửa thành công
            }
            else
            {
                return null; // Không tìm thấy Loại Sản phẩm với Id tương ứng
            }
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
