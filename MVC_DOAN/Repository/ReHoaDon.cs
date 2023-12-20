using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Data;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;
using System.Collections.Generic;

namespace MVC_DOAN.Repository
{
	public class ReHoaDon : IHoaDon
	{

		public readonly DoanContext _context;
		public ReHoaDon(DoanContext context)
		{
			_context = context;
		}
		public bool Add(Donhang donhang)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Donhang donhang)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<HoaDonVM>> GetAll()
		{
			List<HoaDonVM> hoaDonVMs = await _context.Donhangs
		.Join(_context.Users,
			dh => dh.TaikhoanId,
			u => u.Id,
			(dh, u) => new HoaDonVM
			{
				Id = dh.Id,
				Tongtien = dh.Tongtien,
				Ngaytao = dh.Ngaytao,
				Ngaygiao = dh.Ngaygiao,
				Phuongthucthanhtoan = dh.Phuongthucthanhtoan,
				Trangthaithanhtoan = dh.Trangthaithanhtoan,
				Trangthaidonhang = dh.Trangthaidonhang,
				TaikhoanId = dh.TaikhoanId,
				Emailnguoidung = u.Email
			})
		.ToListAsync();
			return hoaDonVMs;
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Donhang donhang)
		{
			_context.Update(donhang);
			return Save();
		}

		public bool UpdateTTHD(EditTinhTrangHoaDonVM edittthd)
		{
			bool isUpdated = false;
			var hoaDon = _context.Donhangs.FirstOrDefault(dh => dh.Id == edittthd.Id);
			if (hoaDon != null)
			{
				if (edittthd.Ngaygiaohang != null) hoaDon.Ngaygiao = edittthd.Ngaygiaohang;
				hoaDon.Trangthaidonhang = edittthd.Tinhtrangdonhang;
				hoaDon.Ngaygiao = edittthd.Ngaygiaohang;
				if (edittthd.TrangthaiTT != null) hoaDon.Trangthaithanhtoan = edittthd.TrangthaiTT;
				_context.SaveChanges();
				isUpdated = true;
			}
			return isUpdated;
		}
	}
}
