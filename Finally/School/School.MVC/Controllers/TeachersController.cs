using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using School.BLL.Services.Teacher;
using School.Core.Models;
using School.Core.Models.Pages;
using School.Core.ShortModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace School.MVC.Controllers
{
    [Authorize(Roles = "admin, manager, student")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public TeachersController(
            ITeacherService teacherService,
            IMapper mapper,
            IWebHostEnvironment appEnvironment,
            UserManager<IdentityUser> userManager)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
        }
        #region Index - get first 10 teachers
        public async Task<IActionResult> Index(PaginationOptions options)
        {
            var teachers = await _teacherService.GetByPages(options);
            return View(teachers);
        }
        #endregion

        #region Edit teacher
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            var modelTeacher = id.HasValue? _mapper.Map<TeacherModel>(await _teacherService.GetById(id.Value)) : new TeacherModel();

            return View(_mapper.Map<TeacherModel>(modelTeacher));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(teacherModel);

                if (teacherModel.Id > 0)
                    await _teacherService.Update(teacher);
                else
                {
                    IdentityUser user = new();

                    user.UserName = teacher.Email;
                    user.Email = teacher.Email;
                    user.EmailConfirmed = true;

                    teacher.UserId = user.Id;

                    IdentityResult result = _userManager.CreateAsync(user, teacherModel.Password).Result;

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "manager").Wait();
                        await _teacherService.Create(teacher);
                    }
                    else
                        return RedirectToAction(nameof(Edit), new { id = teacherModel.Id });
                }
                return RedirectToAction("Index");
            }
            return View(teacherModel);
        }
        #endregion

        #region Delete teacher
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(TeacherModel teacherModel)
        {
            var teacher = _mapper.Map<Teacher>(teacherModel);
            var userTeacher = await _userManager.FindByIdAsync(teacher.UserId);

            await _userManager.DeleteAsync(userTeacher);
            await _teacherService.Delete(teacher.Id);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Upload photo as for teacher
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int id, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                var path = "/Files/" + uploadedFile.FileName + DateTime.Now.Ticks.ToString();

                // save file to file system
                await using var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);

                await uploadedFile.CopyToAsync(fileStream);

                //save file to DB (Person)
                await using var memoryStream = new MemoryStream();

                await uploadedFile.CopyToAsync(memoryStream);

                var content = memoryStream.ToArray();

                await _teacherService.SavePhoto(id, content);
            }

            return RedirectToAction(nameof(Edit), new { Id = id });
        }
        #endregion

        #region Error Action
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}