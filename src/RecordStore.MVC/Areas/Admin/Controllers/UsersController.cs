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

        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userServices.GetUser(id);

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles
                .Select(r => new RoleViewModel { Id = r.Id, Name = r.Name, IsSelected = userRoles.Contains(r.Name) })
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
            var existingUser = await _userServices.GetUser(editUserViewModel.Id);
            if (existingUser is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingUser.Email = editUserViewModel.Email;
                existingUser.UserName = editUserViewModel.Username;
                existingUser.NormalizedEmail = editUserViewModel.Email.ToUpper();
                existingUser.NormalizedUserName = editUserViewModel.Username.ToUpper();

                if (!string.IsNullOrWhiteSpace(editUserViewModel.Password))
                {
                    var passwordHasher = new PasswordHasher<IdentityUser>();
                    existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, editUserViewModel.Password);
                }

                await _userServices.UpdateUser(existingUser);

                var currentUserRoles = await _userManager.GetRolesAsync(existingUser);
                var selectedRoles = editUserViewModel.Roles.Where(r => r.IsSelected).Select(r => r.Name);

                var rolesToAdd = selectedRoles.Except(currentUserRoles).ToList();
                var rolesToRemove = currentUserRoles.Except(selectedRoles).ToList();


                await _userManager.AddToRolesAsync(existingUser, rolesToAdd);
                await _userManager.RemoveFromRolesAsync(existingUser, rolesToRemove);
            }
            return View(editUserViewModel);
        }
    }
}
