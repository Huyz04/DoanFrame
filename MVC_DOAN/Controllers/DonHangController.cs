using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;

namespace MVC_DOAN.Controllers
{
    public class DonHangController : Controller
    {
        private readonly IDonHang _DHI;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DonHangController(IDonHang DHI, IHttpContextAccessor httpContextAccessor)
        {
            _DHI = DHI;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<int> Create(Donhang donhang)
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            if (curUserId == null) return -1;
                try
                {
                    var DH = new Donhang
                    {
                        Phuongthucthanhtoan = donhang.Phuongthucthanhtoan,
                        Trangthaidonhang = donhang.Trangthaidonhang,
                        TaikhoanId = curUserId,
                        DiachiId = donhang.DiachiId,
                        Trangthaithanhtoan = donhang.Trangthaithanhtoan,
                        Ngaytao = DateTime.Now,
                        Tongtien = 0
                    };
                    var a = await _DHI.Add(DH);
                    if (a > 0) return a;
                    else return -1;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi ở đây, ví dụ:
                    Console.WriteLine(ex.Message);
                    return -1;
                }
        }

    }
}
