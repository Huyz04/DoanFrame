using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_DOAN.Interface;
using MVC_DOAN.Models;
using MVC_DOAN.Repository;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _iUser;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<Taikhoan> _userManager;
		public UserController(IUser iUser, IHttpContextAccessor httpContextAccessor, UserManager<Taikhoan> userManager)
		{
			_iUser = iUser;
			_httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
		}
		[HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _iUser.GetAllTaikhoan();
            List<UserVM> result = new List<UserVM>();
            foreach(var user in users)
            {
                var userVM = new UserVM()
                {
                    Id = user.Id,
                    Mail = user.Mail,
                    Matkhau = user.Matkhau,
                    Nickname = user.Nickname,
                };
                result.Add(userVM);

            };
            return View(result);
        }

        public async Task<IActionResult> Detail()
        {
			
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			var user = await _userManager.GetUserAsync(User);
			var userEmail = user.Email;
			var userDetailVM = new UserDetailVM()
            {
                Id = curUserId,
                Mail = userEmail,
                Nickname = user.Nickname,
            };
            return View(userDetailVM);
        }
        [HttpPost]
		public async Task<IActionResult> UpdateNickNameByEmail(string email, string newNickName)
		{
			var user = await _userManager.FindByEmailAsync(email);

			if (user != null)
			{
				user.Nickname = newNickName;
				await _userManager.UpdateAsync(user);
                return RedirectToAction("Detail", "User");
			}
            return RedirectToAction("Detail", "User");

		}

		public async Task<IActionResult> Order()
        {
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            DonHangUser donHangs;
            var user = await _userManager.FindByIdAsync(curUserId);
            string name = user.Nickname;
            string mail = user.Email;
            donHangs = await _iUser.GetDonHangUsersByTaiKhoanID(curUserId,name,mail);
            return View(donHangs);
        }
		public async Task<IActionResult> Address()
		{
			var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
			var user = await _userManager.FindByIdAsync(curUserId);
			string name = user.Nickname;
			string mail = user.Email;
			DiaChiVM diachis;
           diachis = await _iUser.GetDiachibyId(curUserId,name,mail);
			return View(diachis);
		}
        public async Task<IActionResult> GetUser()
        {
            return View();
        }
	}
}
