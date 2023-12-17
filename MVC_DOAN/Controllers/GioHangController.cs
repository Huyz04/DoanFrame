using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class GioHangController : Controller
    {
        private readonly IGioHang _GHI;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GioHangController(IGioHang GHI, IHttpContextAccessor httpContextAccessor)
        {
            _GHI = GHI;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> GetGioHang()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            GioHangVM giohangvm = await  _GHI.GetGioHangById(curUserId);
            return View(giohangvm);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Ctgh ctgh)
        {
            if (ModelState.IsValid)
            {
                var CTGH = new Ctgh
                {
                    Soluong = ctgh.Soluong,
                    SanphamId = ctgh.SanphamId,
                    TaikhoanId = _httpContextAccessor.HttpContext.User.GetUserId(),
            };
                _GHI.Add(CTGH);
                return RedirectToAction("GetGioHang", "GioHang");
            }
            else
            {
                ModelState.AddModelError("", "Them vao gio hang khong thanh cong!");
            }
            ModelState.AddModelError("", "Them vao gio hang khong thanh cong!");
            return RedirectToAction("Index", "SanPham");
        }
    }
}
