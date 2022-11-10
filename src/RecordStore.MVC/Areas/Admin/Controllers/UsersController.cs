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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(IUserServices userServices, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userServices = userServices;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = (await _userServices.GetUsers())
                .Select(u => new GetUserViewModel { Id = u.Id, Email = u.Email, Username = u.UserName, IsLockedout = u.LockoutEnd is not null })
                .ToList();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Lockout([FromForm] Guid id)
        {
            await _userServices.Lockout(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveLockout([FromForm] Guid id)
        {
            await _userServices.RemoveLockout(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
