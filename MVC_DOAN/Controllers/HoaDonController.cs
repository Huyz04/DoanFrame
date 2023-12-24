using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class HoaDonController : Controller
    {

		private readonly IHoaDon _HDI;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public HoaDonController(IHoaDon HDI, IHttpContextAccessor httpContextAccessor)
		{
			_HDI = HDI;
			_httpContextAccessor = httpContextAccessor;
		}
		public async Task<IActionResult> Index()
        {
            return View();
        }
		public async Task<IActionResult> GetHoaDon()
		{

			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			if (curUserId == null) return RedirectToAction("Login", "Account");
			IEnumerable<HoaDonVM> donhangs = await _HDI.GetAll();
			return View(donhangs);
		}
		[HttpPost]
		public bool Edit([FromBody] EditTinhTrangHoaDonVM edhd)
		{

		return 	_HDI.UpdateTTHD(edhd);
			
		}
		public async Task<IActionResult> GetThongKe(int nam)
		{
			var Thongke = await _HDI.GetThongKe(nam);
			Thongke.nam = nam;
			return View(Thongke);
		}

    }
}
