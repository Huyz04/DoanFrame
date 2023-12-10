using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;

namespace MVC_DOAN.Repository
{
    public class ReDashboard : IDashboard

    {
        private readonly DoanContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReDashboard(DoanContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Loaisanpham>> GetAllUserLoaiSanPham()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userLoaiSanPham = _context.Loaisanphams.Where(r => r.Taikhoan.Id == curUser);
            return userLoaiSanPham.ToList();
        }

        public async Task<List<Sanpham>> GetAllUserSanPham()
        { 
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userSanPham = _context.Sanphams.Where(r => r.Taikhoan.Id == curUser);
            return userSanPham.ToList();
        }
    }
}
