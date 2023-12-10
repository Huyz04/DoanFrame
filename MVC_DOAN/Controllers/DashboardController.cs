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

        public DashboardController(IDashboard dashboard)
        {
            _dashboard = dashboard;
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
    }
}
