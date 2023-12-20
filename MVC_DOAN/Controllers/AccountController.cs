using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Data;
using MVC_DOAN.Models;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Taikhoan> _userManager;
        private readonly SignInManager<Taikhoan> _signInManager;
        private readonly DoanContext _context;
        public AccountController(UserManager<Taikhoan> userManager,
          SignInManager<Taikhoan> signInManager,
          DoanContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }
        [HttpPost]
        public  async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                //User is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
						var roles = await _userManager.GetRolesAsync(user);
						if (roles.Contains("admin"))
						{
							// Nếu người dùng có vai trò Admin, điều hướng đến trang Admin
							return RedirectToAction("AdminSanPham", "SanPham");
						}
						else if (roles.Contains("user"))
						{
							// Nếu người dùng có vai trò User, điều hướng đến trang User
							return RedirectToAction("Index", "Home");
						}
						else
						{
							// Người dùng không có vai trò được xác định, điều hướng đến trang mặc định
							return RedirectToAction("Index", "Home");
						}

                    }
                }
                //Password is incorrect
                TempData["ErrorMessage"] = "Sai mật khẩu, vui lòng thử lại";
                return View(loginViewModel);
            }
            //User not found
            TempData["ErrorMessage"] = "Sai tài khoản, vui lòng thử lại!";
            return View(loginViewModel);
        }

        [HttpGet]
		public IActionResult Register()
		{
			var response = new RegisterViewModel();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
		{
			if (!ModelState.IsValid) return View(registerViewModel);

			var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
			if (user != null)
			{
				TempData["ErrorMessage"] = "Email này đã được sử dụng";
				return View(registerViewModel);
			}

			var newUser = new Taikhoan()
			{
				Email = registerViewModel.EmailAddress,
				UserName = registerViewModel.EmailAddress,
                Nickname = "User"
			};
			var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

			if (newUserResponse.Succeeded)
				await _userManager.AddToRoleAsync(newUser, UserRoles.User);
			else
			{
				foreach (var error in newUserResponse.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);

				}
				return View(registerViewModel);
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(string email, string oldPassword, string newPassword)
		{
			// Tìm người dùng với email
			var user = await _userManager.FindByEmailAsync(email);

			if (user != null)
			{
				// Kiểm tra mật khẩu cũ
				var isOldPasswordCorrect = await _userManager.CheckPasswordAsync(user, oldPassword);

				if (isOldPasswordCorrect)
				{
					// Thay đổi mật khẩu
					var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

					if (result.Succeeded)
					{
						// Đăng nhập lại người dùng (nếu cần)
						await _signInManager.RefreshSignInAsync(user);
						TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";
						// Xử lý sau khi thay đổi mật khẩu thành công
						return RedirectToAction("ChangePasswordSuccess");
					}
					else
					{
						TempData["ErrorMessage"] = "Đổi mật khẩu thất bại!";
						// Xử lý khi thay đổi mật khẩu không thành công
						return RedirectToAction("ChangePasswordFailed");
					}
				}
				else
				{
					TempData["ErrorMessage"] = "Mật khẩu cũ chưa đúng!";
					// Xử lý khi mật khẩu cũ không đúng
					return RedirectToAction("IncorrectOldPassword");
				}
			}

			// Xử lý khi không tìm thấy người dùng
			return RedirectToAction("UserNotFound");
		}

		public IActionResult ChangePasswordSuccess()
		{
			TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";
			return RedirectToAction("Login","Account");
		}

		public IActionResult IncorrectOldPassword()
		{
			TempData["ErrorMessage"] = "Mật khẩu cũ không chính xác!";
			return RedirectToAction("Detail", "User");
		}

		public IActionResult ChangePasswordFailed()
		{
			TempData["ErrorMessage"] = "Đổi mật khẩu thất bại!";
			return RedirectToAction("Detail", "User");
		}
	}
}
