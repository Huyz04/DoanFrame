using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Data;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
	public class NguoiDungController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Info()
		{
			return View();
		}
		public IActionResult Address()
		{
			return View();
		}
		public IActionResult Order()
		{
			return View();
		}
	}
}
