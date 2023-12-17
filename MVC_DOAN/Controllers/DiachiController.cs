using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;

namespace MVC_DOAN.Controllers
{
    public class DiachiController : Controller
    {
        private readonly IDiaChi _DCI;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DiachiController(IDiaChi DCI, IHttpContextAccessor httpContextAccessor)
        {
            _DCI = DCI;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Diachi diachi)
        {
            if (ModelState.IsValid)
            {
                var DIACHI = new Diachi
                {
                    Hotennguoinhan = diachi.Hotennguoinhan,
                    Sdt = diachi.Sdt,
                    Tinh = diachi.Tinh,
                    Huyen = diachi.Huyen,
                    Xa = diachi.Xa,
                    Diachichitiet = diachi.Diachichitiet,
                    TaikhoanId = _httpContextAccessor.HttpContext.User.GetUserId(),
                };
                _DCI.Add(DIACHI);
                return RedirectToAction("GetGioHang", "GioHang");
            }
            else
            {
                ModelState.AddModelError("", "Them vao gio hang khong thanh cong!");
            }
            ModelState.AddModelError("", "Them vao gio hang khong thanh cong!");
            return RedirectToAction("Index", "SanPham");
        }
        public async Task<IActionResult> DeleteGioHang(int Id)
        {
            var diachi = await _DCI.GetDiaChiById(Id);
            if (diachi == null) return View("Error");
            _DCI.Delete(diachi);
            return RedirectToAction("GetGioHang", "GioHang");
        }
    }
    
}
