using MVC_DOAN.Interface;
using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Data;
using MVC_DOAN.Models;

namespace MVC_DOAN.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        private readonly ILoaiSanPham _LSPI;

        public LoaiSanPhamController(ILoaiSanPham LSPI)
        {
            _LSPI = LSPI;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Loaisanpham> loaiSanPhams = await _LSPI.GetAll();
            return View(loaiSanPhams);
        }
        public async Task<IActionResult> Detail(string Id)
        {
            Loaisanpham LSP = await _LSPI.GetById(Id);
            return View(LSP);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Loaisanpham LSP)
        {
            if (!ModelState.IsValid)
            {
                return View(LSP);
            }
            _LSPI.Add(LSP);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var LSP = await _LSPI.GetById(Id);
            if (LSP == null) return View("Error");
            return View(LSP);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string Id, Loaisanpham LSP)
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
