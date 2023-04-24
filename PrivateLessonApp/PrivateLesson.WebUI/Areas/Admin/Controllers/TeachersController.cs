using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.WebUI.Areas.Admin.Models.ViewModels;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeachersController : Controller
    {
        private ITeacherService _teacherService;
        private IStudentService _studentService;
        private IImageService _imageService;

        public TeachersController(ITeacherService teacherService, IStudentService studentService, IImageService imageService)
        {
            _teacherService = teacherService;
            _studentService = studentService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index(TeacherListViewModel teacherListViewModel)
        {
            List<Teacher> teacherList;
            if (teacherListViewModel.Teachers == null)
            {
                teacherList = await _teacherService.GetAllTeachersFullDataAsync(teacherListViewModel.ApprovedStatus);
                List<TeacherViewModel> teachers = new List<TeacherViewModel>();
                foreach (var teacher in teacherList)
                {
                    teachers.Add(new TeacherViewModel
                    {
                        Id = teacher.Id,
                        FirstName = teacher.User.FirstName,
                        LastName = teacher.User.LastName,
                        Gender = teacher.User.Gender,
                        DateOfBirth = teacher.User.DateOfBirth,
                        City = teacher.User.City,
                        Phone = teacher.User.Phone,
                        CreatedDate = teacher.CreatedDate,
                        UpdatedDate = teacher.UpdatedDate,
                        IsApproved = teacher.IsApproved,
                        Url = teacher.Url,
                        Graduation = teacher.Graduation,
                        UserId = teacher.UserId,
                        User = teacher.User,
                        Students = teacher.TeacherStudents.Select(ts => new StudentViewModel
                        {
                            Id = ts.Student.Id,
                            UserId = ts.Student.UserId,
                            User = ts.Student.User,
                            FirstName = ts.Student.User.FirstName,
                            LastName = ts.Student.User.LastName,
                            Url = ts.Student.Url
                        }).ToList(),
                        Branches = teacher.TeacherBranches.Select(tb=> new BranchViewModel
                        {
                            Id = tb.Branch.Id,
                            BranchName = tb.Branch.BranchName,
                            Description = tb.Branch.Description,
                            Url = tb.Branch.Url
                        }).ToList(),
                        Image= teacher.Image
                    }) ;
                }
                teacherListViewModel.Teachers = teachers;
            }
            return View(teacherListViewModel);
        }
    }
}
