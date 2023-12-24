using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class VNPAYController : Controller
    {
        private readonly IVnPayService _vnPayService;
        public VNPAYController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Thanhtoan tt)
        {
            var TT = new Thanhtoan
            {
                mail = tt.mail,
                dongia = tt.dongia
            };
            return View(TT);
        }

            public IActionResult CreatePaymentUrl(PaymentInformationModel model)
            {
                var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
                return Redirect(url);
            }

        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response.Success == true && response.TransactionId != "0")
                return View("Success");
            else return RedirectToAction("GetGioHang", "GioHang");
        }
    }
}
