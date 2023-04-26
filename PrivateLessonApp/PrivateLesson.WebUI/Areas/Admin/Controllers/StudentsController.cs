using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Areas.Admin.Models.ViewModels;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private IStudentService _studentService;
        private IImageService _imageService;
        private UserManager<User> _userManager;

        public StudentsController(IStudentService studentService, IImageService imageService, UserManager<User> userManager)
        {
            _studentService = studentService;
            _imageService = imageService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(StudentListViewModel studentListViewModel)
        {
            List<Student> studentList = await _studentService.GetAllStudentsWithTeachersAsync(studentListViewModel.ApprovedStatus);
            List<StudentViewModel> students= new List<StudentViewModel>();
            foreach (var student in studentList)
            {
                students.Add(new StudentViewModel
                {
                    Id = student.Id,
                    FirstName = student.User.FirstName,
                    LastName = student.User.LastName,
                    Gender = student.User.Gender,
                    Phone = student.User.Phone,
                    City = student.User.City,
                    DateOfBirth = student.User.DateOfBirth,
                    CreatedDate = student.CreatedDate,
                    UpdatedDate = student.UpdatedDate,
                    IsApproved = student.IsApproved,
                    Url = student.Url,
                    UserId = student.UserId,
                    User =student.User,
                    Teachers = student.TeacherStudents.Select(ts => new TeacherViewModel
                    {
                        Id = ts.Teacher.Id,
                        User = ts.Teacher.User,
                        FirstName = ts.Teacher.User.FirstName,
                        LastName = ts.Teacher.User.LastName,
                        Url = ts.Teacher.Url
                    }).ToList(),
                    Image= student.Image
                });
            }
            studentListViewModel.Students = students;
            return View(studentListViewModel);
        }
    }
}
