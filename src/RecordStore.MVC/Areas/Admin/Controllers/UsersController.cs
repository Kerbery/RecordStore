using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordStore.MVC.Areas.Admin.Models;
using RecordStore.Service.DTOs;
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

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userServices.GetUser(id);

            var userRoles = await _roleServices.GetUserRolesAsync(Guid.Parse(user.Id));
            var roles = (await _roleServices.GetAllRolesAsync())
                .Select(r => new RoleViewModel { Id = r.Id, Name = r.Name, IsSelected = userRoles.Any(ur => ur.Name == r.Name) })
                .ToList();

            var userViewModel = new EditUserViewModel()
            {
                Id = Guid.Parse(user.Id),
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
                var roles = editUserViewModel.Roles.Select(r => new UserRoleDTO(Name: r.Name, IsInRole: r.IsSelected));
                var updateUserDTO = new UpdateUserDTO
                (
                    Id: editUserViewModel.Id,
                    UserName: editUserViewModel.Username,
                    Password: editUserViewModel.Password,
                    Email: editUserViewModel.Email,
                    Roles: roles
                );

                try
                {
                    await _userServices.UpdateUser(updateUserDTO);
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
                .Select(r => new RoleViewModel { Id = r.Id, Name = r.Name, IsSelected = false })
                .ToList();

            var addUserViewModel = new AddUserViewModel { Roles = roles };

            return View(addUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var roles = addUserViewModel.Roles.Where(r => r.IsSelected).Select(r => r.Name);
                var user = new CreateUserDTO
                (
                    UserName: addUserViewModel.Username,
                    Email: addUserViewModel.Email,
                    Password: addUserViewModel.Password,
                    Roles: roles
                );

                var result = await _userServices.CreateUser(user);

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
