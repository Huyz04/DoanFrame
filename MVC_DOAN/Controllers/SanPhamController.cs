﻿using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.Service;
using MVC_DOAN.ViewModels;
using System.Net;

namespace MVC_DOAN.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ISanPham _SPI;
        private readonly IPhotoService _PhoToService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SanPhamController(ISanPham SPI, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _SPI = SPI;
            _PhoToService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            SanPhamVM sanphamVM = await _SPI.GetAll();
            return View(sanphamVM);
        }
        public async Task<IActionResult> Detail(int Id)
        {
			Sanpham sanpham = await _SPI.GetByIdAsync(Id);
			return View(sanpham);
		}
        [HttpGet]
		public async Task<IActionResult> GetFilter(string timkiem, int MaLSP, string sapxep, int giaduoi, int giatren)
		{
			SanPhamVM sanphamVM = await _SPI.GetFilter( timkiem, MaLSP, sapxep, giaduoi, giatren);
			return View(sanphamVM);
		}

		[HttpGet]
		public async Task<IActionResult> GetFilterAdmin(string timkiem, int MaLSP, string sapxep, int giaduoi, int giatren)
		{
			SanPhamVM sanphamVM = await _SPI.GetFilter(timkiem, MaLSP, sapxep, giaduoi, giatren);
			return View(sanphamVM);
		}

		[HttpGet]
        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createSanPhamViewModel = new CreateSanPhamViewModel { TaikhoanId = curUserId };
            return View(createSanPhamViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSanPhamViewModel SanphamVM)
        {
            
				var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
				var createSanPhamViewModel = new CreateSanPhamViewModel { TaikhoanId = curUserId };
				var result = await _PhoToService.AddPhotoAsync(SanphamVM.Img);

                var club = new Sanpham
                {
                    
                    LoaisanphamId = SanphamVM.LoaisanphamId,
                    Tensp = SanphamVM.Tensp,
                    Dongia = SanphamVM.Dongia,
                    Soluongdaban = SanphamVM.Soluongdaban,
                    Soluongtonkho = SanphamVM.Soluongtonkho,
                    Tinhtrang = SanphamVM.Tinhtrang,
                    TaikhoanId = SanphamVM.TaikhoanId,
                    Img = result.Url.ToString()
                };
               if( _SPI.Add(club))
                return RedirectToAction("AdminSanPham");
           

            return View(SanphamVM);
        }
		public async Task<IActionResult> AdminSanPham()
		{
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			if (curUserId == null) return RedirectToAction("Login", "Account");
			SanPhamVM sanphamVM = await _SPI.GetAll();
            var adsanphamVM = new ADSanphamVM();
            adsanphamVM.sanphamvm = sanphamVM;
			return View(adsanphamVM);
		}
		public async Task<IActionResult> Edit(int Id)
        {
            var SP = await _SPI.GetByIdAsync(Id);
            if (SP == null) return View("Error");
            var SPVM = new EditSanPhamViewModel
            {
                Id = SP.Id,
                LoaisanphamId = SP.LoaisanphamId, 
                Tensp = SP.Tensp,
                Dongia = SP.Dongia,
                Soluongtonkho = SP.Soluongtonkho,
                Tinhtrang = SP.Tinhtrang,
                URL = SP.Img
            };
            return View(SPVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditSanPhamViewModel SPVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit LoaiSanPham");
                return View("Edit", SPVM);
            }
            var DSP = await _SPI.GetByIdAsyncNoTracking(Id);
            if (DSP != null)
            { 
                if ( SPVM.Img != null)
                {
                    if (DSP.Img != null)
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
                    }

                    var photoResult = await _PhoToService.AddPhotoAsync(SPVM.Img);

                    var SP = new Sanpham
                    {
                        Id = Id,
                        Tensp = SPVM.Tensp,
                        LoaisanphamId = SPVM.LoaisanphamId,
                        Dongia = SPVM.Dongia,
                        Soluongtonkho = SPVM.Soluongtonkho,
                        Tinhtrang = SPVM.Tinhtrang,
                        Img = photoResult.Url.ToString(),
                        Mota = SPVM.Mota
                    };
                    _SPI.Update(SP);
                    return RedirectToAction("AdminSanPham");
                }
                else
                {
					var SP = new Sanpham
					{
						Id = Id,
						Tensp = SPVM.Tensp,
						LoaisanphamId = SPVM.LoaisanphamId,
						Dongia = SPVM.Dongia,
						Soluongtonkho = SPVM.Soluongtonkho,
						Tinhtrang = SPVM.Tinhtrang,
                        Img = DSP.Img,
						Mota = SPVM.Mota
					};
					_SPI.Update(SP);
					return RedirectToAction("AdminSanPham");
				}
             }
        else
            {
                return View(SPVM);
            }
        }
		public async Task<IActionResult> EditSP(int Id, EditSanPhamViewModel SPVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Failed to edit LoaiSanPham");
				return View("Edit", SPVM);
			}
			var DSP = await _SPI.GetByIdAsyncNoTracking(Id);
			if (DSP != null)
			{
				if (DSP.Img != null || SPVM.Img != null)
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
				}
				var photoResult = await _PhoToService.AddPhotoAsync(SPVM.Img);

				var SP = new Sanpham
				{
					Id = Id,
					Tensp = SPVM.Tensp,
					LoaisanphamId = SPVM.LoaisanphamId,
					Dongia = SPVM.Dongia,
					Soluongtonkho = SPVM.Soluongtonkho,
					Tinhtrang = SPVM.Tinhtrang,
					Img = photoResult.Url.ToString()
				};
				_SPI.Update(SP);
				return RedirectToAction("GetFilterAdmin");

			}
			else
			{
				return View(SPVM);
			}
		}

	}
}
