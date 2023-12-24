using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Create(Diachi diachi)
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
                    Tinhtrang = "1",
                    Diachichitiet = diachi.Diachichitiet,
                    TaikhoanId = _httpContextAccessor.HttpContext.User.GetUserId(),
                };
                _DCI.Add(DIACHI);
                return RedirectToAction("GetGioHang", "GioHang");
            }
            else
            {
                return RedirectToAction("GetGioHang", "GioHang");
            }
        }
        public async Task<IActionResult> DeleteGioHang(int Id)
        {
            var diachi = await _DCI.GetDiaChiById(Id);
            if (diachi == null) return View("Error");
            diachi.Tinhtrang = "0";
            _DCI.Update(diachi);
            return RedirectToAction("GetGioHang", "GioHang");
        }
        [HttpPost]
        public IActionResult Edit(Diachi diachi)
        {
            if (ModelState.IsValid)
            {
                var DIACHI = new Diachi
                {
                    Id = diachi.Id,
                    Hotennguoinhan = diachi.Hotennguoinhan,
                    Sdt = diachi.Sdt,
                    Tinh = diachi.Tinh,
                    Huyen = diachi.Huyen,
                    Xa = diachi.Xa,
                    Tinhtrang = "1",
                    Diachichitiet = diachi.Diachichitiet,
                    TaikhoanId = _httpContextAccessor.HttpContext.User.GetUserId(),
                };
                _DCI.Update(DIACHI);
                return RedirectToAction("GetGioHang", "GioHang");
            }
            else
            {
                return RedirectToAction("GetGioHang", "GioHang");
            }
        }
        [HttpPost]
        public IActionResult CreateUser(Diachi diachi)
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
                    Tinhtrang = "1",
                    Diachichitiet = diachi.Diachichitiet,
                    TaikhoanId = _httpContextAccessor.HttpContext.User.GetUserId(),
                };
                _DCI.Add(DIACHI);
                return RedirectToAction("Address", "User");
            }
            else
            {
                return RedirectToAction("Address", "User");
            }
        }
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var diachi = await _DCI.GetDiaChiById(Id);
            if (diachi == null) return View("Error");
            diachi.Tinhtrang = "0";
            _DCI.Update(diachi);
            return RedirectToAction("Address", "User");
        }
        [HttpPost]
        public IActionResult EditUser(Diachi diachi)
        {
            if (ModelState.IsValid)
            {
                var DIACHI = new Diachi
                {
                    Id = diachi.Id,
                    Hotennguoinhan = diachi.Hotennguoinhan,
                    Sdt = diachi.Sdt,
                    Tinh = diachi.Tinh,
                    Huyen = diachi.Huyen,
                    Xa = diachi.Xa,
                    Tinhtrang = "1",
                    Diachichitiet = diachi.Diachichitiet,
                    TaikhoanId = _httpContextAccessor.HttpContext.User.GetUserId(),
                };
                _DCI.Update(DIACHI);
                return RedirectToAction("Address", "User");
            }
            else
            {
                return RedirectToAction("Address", "User");
            }
        }
    }
    
}
