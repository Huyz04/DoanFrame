using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.Service;
using MVC_DOAN.ViewModels;
using System.Net;
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
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public async Task<IActionResult> GetGioHang()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			if (curUserId == null) return RedirectToAction("Login", "Account");
			GioHangVM giohangvm = await  _GHI.GetGioHangById(curUserId);
            return View(giohangvm);

        }

        [HttpPost]
        public  bool Create([FromBody] Ctgh ctgh)
        {
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            if (curUserId == null) return false;
            ctgh.TaikhoanId = curUserId;
            var ctghtt =  _GHI.Check(ctgh);
            if (ctghtt != null)
            {
                
                if (ModelState.IsValid)
                {
                    ctghtt.Soluong += 1;
                    _GHI.Update(ctghtt);
                    return true;
                }
            }
                if (ModelState.IsValid)
                {
                    var CTGH = new Ctgh
                    {
                        Soluong = ctgh.Soluong,
                        SanphamId = ctgh.SanphamId,
                        TaikhoanId = curUserId
                    };
                    _GHI.Add(CTGH);
                return true; 
                }
            else
            {
                ModelState.AddModelError("", "Them vao gio hang khong thanh cong!");
            }
            ModelState.AddModelError("", "Them vao gio hang khong thanh cong!");
            return false;
        }

		[HttpPost]
		public async Task<IActionResult> Edit(Ctgh ctgh)
		{
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			if (curUserId == null) return RedirectToAction("Login", "Account");
            if (ctgh.Soluong <1) return RedirectToAction("GetGioHang", "GioHang");
            if (ModelState.IsValid)
			{
				var CTGH = new Ctgh
				{
                    Id = ctgh.Id,
					Soluong = ctgh.Soluong,
					SanphamId = ctgh.SanphamId,
					TaikhoanId = curUserId
				};
				_GHI.Update(CTGH);
				return RedirectToAction("GetGioHang", "GioHang");
			}
			else
			{
				ModelState.AddModelError("", "Chinh sua gio hang khong thanh cong!");
			}
			ModelState.AddModelError("", "Chinh sua gio hang khong thanh cong!");
			return RedirectToAction("Index", "SanPham");
		}
        public async Task<IActionResult> DeleteGioHang(int Id)
        {
            var giohang = await _GHI.GetCtghById(Id);
            if (giohang == null) return View("Error");
            _GHI.Delete(giohang);
            return RedirectToAction("GetGioHang", "GioHang");
        }
    }
}
