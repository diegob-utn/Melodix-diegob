using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Melodix.Models.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Melodix.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserRolesController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /Admin/UserRoles/Index
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new List<(ApplicationUser user, IList<string> roles)>();
            foreach(var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result;
                userRoles.Add((user, roles));
            }
            return View(userRoles);
        }

        // GET: /Admin/UserRoles/Edit?id=...
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
                return NotFound();

            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserRolesViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                Roles = allRoles,
                SelectedRoles = userRoles.ToList()
            };

            return View(model);
        }

        // POST: /Admin/UserRoles/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserRolesViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Roles = _roleManager.Roles.Select(r => r.Name).ToList();
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if(user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
            var rolesToAdd = model.SelectedRoles.Except(userRoles);
            var rolesToRemove = userRoles.Except(model.SelectedRoles);

            await _userManager.AddToRolesAsync(user, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("Index");
        }
    }

    public class EditUserRolesViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }
}