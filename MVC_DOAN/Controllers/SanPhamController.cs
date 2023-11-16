using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPham _SPI;
        private readonly IPhotoService _PhoToService;

        public SanPhamController(ISanPham SPI, IPhotoService photoService)
        {
            _SPI = SPI;
            _PhoToService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Sanpham> SanPhams = await _SPI.GetAll();
            return View(SanPhams);
        }
        public async Task<IActionResult> Detail(string Id)
        {

            Sanpham SP = await _SPI.GetByIdAsync(Id);
            return View(SP);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSanPhamViewModel SPVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _PhoToService.AddPhotoAsync(SPVM.Img);
                var SP = new Sanpham
                {
                    Masp = SPVM.Masp,
                    Malsp = SPVM.Malsp,
                    Tensp = SPVM.Tensp,
                    Dongia = SPVM.Dongia,
                    Soluongdaban = SPVM.Soluongdaban,
                    Soluongtonkho = SPVM.Soluongtonkho,
                    Tinhtrang = SPVM.Tinhtrang,
                    Img = result.Url.ToString()
                };
                _SPI.Add(SP);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Photo upload failed");
            }
            return View(SPVM);
        }

        public async Task<IActionResult> Edit(string Id)
        {
            var SP = await _SPI.GetByIdAsync(Id);
            if (SP == null) return View("Error");
            var SPVM = new EditSanPhamViewModel
            {
                Masp = SP.Masp,
                Malsp = SP.Malsp,
                Tensp = SP.Tensp,
                Dongia = SP.Dongia,
                Soluongtonkho = SP.Soluongtonkho,
                Tinhtrang = SP.Tinhtrang,
                URL = SP.Img
            };
            return View(SPVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string Id, EditSanPhamViewModel SPVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit LoaiSanPham");
                return View("Edit", SPVM);
            }
            var DSP = await _SPI.GetByIdAsyncNoTracking(Id);
            if (DSP != null)
            {
                try
                {
                    await _PhoToService.DeletePhotoAsync(DSP.Img);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete Photo");
                    return View(SPVM);
                }
                var photoResult = await _PhoToService.AddPhotoAsync(SPVM.Img);

                var SP = new Sanpham
                {
                    Masp = Id,
                    Tensp = SPVM.Tensp,
                    Malsp = SPVM.Malsp,
                    Dongia = SPVM.Dongia,
                    Soluongtonkho = SPVM.Soluongtonkho,
                    Tinhtrang = SPVM.Tinhtrang,
                    Img = photoResult.Url.ToString()
                };
                _SPI.Update(SP);
                return RedirectToAction("Index"); 

             }
        else
            {
                return View(SPVM);
            }
        }
    }
}
