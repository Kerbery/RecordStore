using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordStore.Core.Extensions;
using RecordStore.Core.ViewModels.User;
using RecordStore.Service.Interfaces;

namespace RecordStore.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IRoleServices _roleServices;

        public UsersController(IUserServices userServices, IRoleServices roleServices)
        {
            _userServices = userServices;
            _roleServices = roleServices;
        }

        public async Task<IActionResult> Index()
        {
            var users = (await _userServices.GetUsers())
                .Select(u => u.AsViewModel());

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

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userServices.GetUser(id);

            var userRoles = await _roleServices.GetUserRolesAsync(user.Id);
            var roles = (await _roleServices.GetAllRolesAsync())
                .Select(role => role.AsViewModel(isSelected: userRoles.Any(userRole => userRole.Name == role.Name)))
                .ToList();

            var userViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Roles = roles,
            };

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userServices.UpdateUser(editUserViewModel);
                }
                catch
                {
                    return NotFound();
                }
            }
            return View(editUserViewModel);
        }

        public async Task<IActionResult> Add()
        {
            var roles = (await _roleServices.GetAllRolesAsync())
                .Select(r => r.AsViewModel())
                .ToList();

            var addUserViewModel = new AddUserViewModel { Roles = roles };

            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userServices.CreateUser(addUserViewModel);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(addUserViewModel);
        }
    }
}
