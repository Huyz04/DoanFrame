﻿using Microsoft.AspNetCore.Identity;
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
                        return RedirectToAction("Index", "Home");
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
				UserName = registerViewModel.EmailAddress
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

	}
}
