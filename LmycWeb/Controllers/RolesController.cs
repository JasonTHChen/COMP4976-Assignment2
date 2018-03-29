using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LmycWeb.Controllers
{
    [Authorize(Policy = "RequireAdmin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var roles = _roleManager.Roles;
            
            return View(await roles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRole = await _roleManager.FindByIdAsync(id);

            if (identityRole == null)
            {
                return NotFound();
            }

            var users = _userManager.GetUsersInRoleAsync(identityRole.Name).Result;

            var role = new RoleViewModel
            {
                RoleId = identityRole.Id,
                RoleName = identityRole.Name,
                Users = users
            };

            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(role.Name))
                {
                    return View();
                }

                await _roleManager.CreateAsync(role);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRole = await _roleManager.FindByIdAsync(id);

            if (identityRole == null)
            {
                return NotFound();
            }

            var roleUsers = _userManager.GetUsersInRoleAsync(identityRole.Name).Result;

            var users = await _userManager.Users.ToListAsync();

            foreach (var u in roleUsers)
            {
                if (users.Contains(u))
                {
                    users.Remove(u);
                }
            }

            var role = new RoleViewModel
            {
                RoleId = identityRole.Id,
                RoleName = identityRole.Name,
                Users = users
            };

            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityRole = await _roleManager.FindByIdAsync(id);

            if (identityRole.Name.Equals("Admin") || identityRole == null)
            {
                return NotFound();
            }   

            var users = _userManager.GetUsersInRoleAsync(identityRole.Name).Result;

            var role = new RoleViewModel
            {
                RoleId = identityRole.Id,
                RoleName = identityRole.Name,
                Users = users
            };

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role.Name.Equals("Admin") || role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Roles/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, model.RoleName);

            return RedirectToAction(nameof(Edit), new { id = model.RoleId });
        }

        // POST: Roles/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(RoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user.UserName.Equals("a") || user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(user, model.RoleName);

            return RedirectToAction(nameof(Details), new { id = model.RoleId });
        }
    }
}