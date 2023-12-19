using Microsoft.AspNetCore.Mvc;
using MVC_DOAN.Interface;
using MVC_DOAN.Repository;
using MVC_DOAN.ViewModels;

namespace MVC_DOAN.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _iUser;

        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }
        [HttpGet("users")]
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
                    Phanloai = user.Phanloai,
                    Nickname = user.Nickname,
                };
                result.Add(userVM);

            };
            return View(result);
        }

        public async Task<IActionResult> Detail(string Id)
        {
            var user = await _iUser.GetTaikhoanbyId(Id);
            var userDetailVM = new UserDetailVM()
            {
                Id = user.Id,
                Mail = user.Mail,
                Matkhau = user.Matkhau,
                Phanloai = user.Phanloai,
                Nickname = user.Nickname,
            };
            return View(userDetailVM);
        }
        public IActionResult Get()
        {
            return  View();
        }
    }
}
