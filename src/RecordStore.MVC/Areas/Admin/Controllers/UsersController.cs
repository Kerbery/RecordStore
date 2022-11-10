using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecordStore.MVC.Areas.Admin.Models;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<IActionResult> Index()
        {
            var users = (await _userServices.GetUsers())
                .Select(u => new GetUserViewModel { Id = u.Id, Email = u.Email, Username = u.UserName, IsLockedout = u.LockoutEnd is not null })
                .ToList();

            return View(users);
        }
    }
}
