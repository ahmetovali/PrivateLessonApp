using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.WebUI.Models.ViewModels;
using System.Diagnostics;

namespace PrivateLesson.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;
        private IImageService _imageService;
        private IAdvertService _advertService;

        public HomeController(ITeacherService teacherService, IBranchService branchService, IImageService imageService, IAdvertService advertService)
        {
            _teacherService = teacherService;
            _branchService = branchService;
            _imageService = imageService;
            _advertService = advertService;
        }

        public async Task<IActionResult> Index(string branchurl)
        {
            List<Teacher> teachers = await _teacherService.GetAllTeachersFullDataAsync(true, branchurl);
            List<TeacherModel> teacherModelList = new List<TeacherModel>();
            teacherModelList = teachers.Select(t => new TeacherModel
            {
                Id = t.Id,
                FirstName = t.User.FirstName,
                LastName = t.User.LastName,
                CreatedDate = t.CreatedDate,
                UpdatedDate = t.UpdatedDate,
                IsApproved = t.IsApproved,
                Url = t.Url,
                Graduation = t.Graduation,
                UserId = t.UserId,
                ImageUrl = t.User.Image.Url,
                TeacherBranches = t.TeacherBranches.Select(tb => tb.Branch).ToList(),
                TeacherStudents = t.TeacherStudents.Select(ts => ts.Student).ToList(),

            }).ToList();
            if (RouteData.Values["branchurl"] != null)
            {
                ViewBag.SelectedBranchName = await _branchService.GetBranchNameByUrlAsync(RouteData.Values["branchurl"].ToString());
            }

            return View(teacherModelList);
        }

       


    }
}