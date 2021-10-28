using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.Core.ShortModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentityApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        #region Get roles to list
        public IActionResult RolesList()
        {
            return View(_roleManager.Roles.ToList());
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                return View(name);
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                IdentityRole role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    IdentityResult result = await _roleManager.DeleteAsync(role);
                }
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        public async Task<IActionResult> UserList()
        {
            var users = _userManager.Users.ToList();
            List<string> listRoles = new();
            foreach (var item in users)
            {
                var userRoles = await _userManager.GetRolesAsync(item);
                foreach (var item2 in userRoles)
                {
                    listRoles.Add(item2);
                }
            }
            ViewBag.Roles = listRoles;
            return View(users);
        }

        public async Task<IActionResult> Edit(string userId)
        {
            try
            {  // получаем пользователя
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    // получем список ролей пользователя
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var allRoles = _roleManager.Roles.ToList();
                    ChangeRoleViewModel model = new ChangeRoleViewModel
                    {
                        UserId = user.Id,
                        UserEmail = user.Email,
                        UserRoles = userRoles,
                        AllRoles = allRoles
                    };
                    return View(model);
                }
                return NotFound();
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            try
            {
                // получаем пользователя
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    // получем список ролей пользователя
                    var userRoles = await _userManager.GetRolesAsync(user);
                    // получаем все роли
                    var allRoles = _roleManager.Roles.ToList();
                    // получаем список ролей, которые были добавлены
                    var addedRoles = roles.Except(userRoles);
                    // получаем роли, которые были удалены
                    var removedRoles = userRoles.Except(roles);

                    await _userManager.AddToRolesAsync(user, addedRoles);

                    await _userManager.RemoveFromRolesAsync(user, removedRoles);

                    return RedirectToAction("UserList");
                }
                return NotFound();
            }

            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction(nameof(Error));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}