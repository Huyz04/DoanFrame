using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class ChiTietDonController : Controller
    {
        private readonly IChiTietDon _CTDI;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChiTietDonController(IChiTietDon CTDI, IHttpContextAccessor httpContextAccessor)
        {
            _CTDI = CTDI;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool Create([FromBody] CreateCTD crCTD)
        {

            if (ModelState.IsValid)
            {
                if (_CTDI.Add(crCTD)) return true;
                else return false;
            }
            else return false;
        }
    }
}
