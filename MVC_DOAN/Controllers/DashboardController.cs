using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboard _dashboard;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardController(IDashboard dashboard, IHttpContextAccessor httpContextAccessor)
        {
            _dashboard = dashboard;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var userLoaiSanPham = await _dashboard.GetAllUserLoaiSanPham();
            var userSanPham = await _dashboard.GetAllUserSanPham();
            var dashboardVM = new DashboardVM()
            {
                Loaisanphams = userLoaiSanPham,
                Sanphams = userSanPham
            };
            return View(dashboardVM);
        }
        //public async Task<IActionResult> EditUserProfile()
        //{
        //    var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
        //    var user = await _dashboard.GetUserById(curUserId);
        //    if (user == null) return View("Error");
        //    var 
        //}
    }
}
