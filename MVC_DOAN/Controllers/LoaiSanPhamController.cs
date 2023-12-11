using MVC_DOAN.Interface;
using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Data;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class LoaiSanPhamController : Controller
    {   
        private readonly ILoaiSanPham _LSPI;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public LoaiSanPhamController(ILoaiSanPham LSPI, IHttpContextAccessor httpContextAccessor)
        {
            _LSPI = LSPI;
            _httpContextAccesor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Loaisanpham> loaiSanPhams = await _LSPI.GetAll();
            return View(loaiSanPhams);
        }
        public async Task<IActionResult> GetTinhtrang()
        {
            IEnumerable<Loaisanpham> loaiSanPhams = await _LSPI.GetTinhtrang();
            return View(loaiSanPhams);
        }
        public async Task<IActionResult> Detail(int Id)
        {
            Loaisanpham LSP = await _LSPI.GetById(Id);
            return View(LSP);
        }
        public IActionResult Create()
        {
            var curUserId = _httpContextAccesor.HttpContext.User.GetUserId();
            var createLoaisanphamVM = new CreateLoaiSanPhamVM { TaikhoanId = curUserId };
            return View(createLoaisanphamVM);
        }
        [HttpPost]
         public async Task<IActionResult> Create(CreateLoaiSanPhamVM LoaiSanphamVM)
            {
                if (ModelState.IsValid)
                {
                var Loaisanphams = new Loaisanpham
                {
                    Tenlsp = LoaiSanphamVM.Tenlsp,
                    Tinhtrang = LoaiSanphamVM.Tinhtrang,
                    TaikhoanId = LoaiSanphamVM.TaikhoanId
                };
                    _LSPI.Add(Loaisanphams);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Upload failed");
                }

                return View(LoaiSanphamVM);
            }

        public async Task<IActionResult> Edit(int Id)
        {
            var LSP = await _LSPI.GetById(Id);
            if (LSP == null) return View("Error");
            return View(LSP);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, Loaisanpham LSP)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit LoaiSanPham");
                return View("Edit", LSP);
            }

            _LSPI.Update(LSP);
            return RedirectToAction("Index");
        }
    }
}
