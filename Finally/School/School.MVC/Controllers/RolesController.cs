using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Student;
using School.BLL.Services.Teacher;
using School.Core.ShortModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentityApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private readonly IStudentService _studentsService;
        private readonly ITeacherService _teacherService;

        public RolesController(
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager,
            IStudentService studentsService,
            ITeacherService teacherService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _studentsService = studentsService;
            _teacherService = teacherService;
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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
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

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var item in userRoles)
                {
                    if (string.Equals(item, "student"))
                    {
                        var students = await _studentsService.GetAll();
                        var student = students.Where(x => x.UserId == id).FirstOrDefault();
                        if (student != null)
                        {
                            await _studentsService.Delete(student.Id);
                            await _userManager.DeleteAsync(user);
                        }
                        else
                            RedirectToAction(nameof(Error));
                    }

                    else if (string.Equals(item, "manager"))
                    {
                        var teachers = await _teacherService.GetAll();
                        var teacher = teachers.Where(x => x.UserId == id).FirstOrDefault();
                        if (teacher != null)
                        {
                            await _teacherService.Delete(teacher.Id);
                            await _userManager.DeleteAsync(user);
                        }
                        else
                            await _userManager.DeleteAsync(user);
                    }

                    else
                    {
                        RedirectToAction(nameof(Error));
                    }
                }
            }
            return RedirectToAction(nameof(UserList));
        }
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
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

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}