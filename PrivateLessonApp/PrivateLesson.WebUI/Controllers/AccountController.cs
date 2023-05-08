using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Core;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.EmailServices;
using PrivateLesson.WebUI.Models.ViewModels.AccountModels;

namespace PrivateLesson.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITeacherService _teacherService;
        private readonly IBranchService _branchService;
        private readonly IStudentService _studentService;
        private readonly INotyfService _notyfService;
        private readonly IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherService, IBranchService branchService, IStudentService studentService, INotyfService notyfService, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherService = teacherService;
            _branchService = branchService;
            _studentService = studentService;
            _notyfService = notyfService;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> TeacherRegister()
        {
            TeacherRegisterViewModel registerViewModel = new TeacherRegisterViewModel
            {
                Branches = await _branchService.GetBranchesAsync(true)
            };

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TeacherRegister(TeacherRegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    Gender = registerViewModel.Gender,
                    DateOfBirth = registerViewModel.DateOfBirth,
                    City = registerViewModel.City,
                    Phone = registerViewModel.Phone,
                    Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(registerViewModel.Image)
                    }
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "OGRETMEN");
                    Teacher teacher = new Teacher
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Url = Jobs.GetUrl(registerViewModel.FirstName + registerViewModel.LastName),
                        Graduation = registerViewModel.Graduation,
                        User = user,
                        IsApproved = true,
                        UserId = user.Id,


                    };
                    await _teacherService.CreateTeacher(teacher, registerViewModel.SelectedBranches);
                    return RedirectToAction("Login", "Account");
                }


            }
            registerViewModel.Branches = await _branchService.GetBranchesAsync(true);
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult StudentRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentRegister(StudentRegisterViewModel studentRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = studentRegisterViewModel.UserName,
                    Email = studentRegisterViewModel.Email,
                    FirstName = studentRegisterViewModel.FirstName,
                    LastName = studentRegisterViewModel.LastName,
                    Gender = studentRegisterViewModel.Gender,
                    DateOfBirth = studentRegisterViewModel.DateOfBirth,
                    City = studentRegisterViewModel.City,
                    Phone = studentRegisterViewModel.Phone,
                    Image = new Image
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        Url = Jobs.UploadImage(studentRegisterViewModel.Image)
                    }
                };
                var result = await _userManager.CreateAsync(user, studentRegisterViewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "OGRENCI");
                    Student student = new Student
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Url = Jobs.GetUrl(studentRegisterViewModel.FirstName + studentRegisterViewModel.LastName),
                        User = user,
                        IsApproved = true,
                        UserId = user.Id,
                    };
                    await _studentService.CreateAsync(student);
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(studentRegisterViewModel);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı");
            }

            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return View();
            }
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "Profiliniz başarıyla onaylanmıştır. Güvenli alışverişler!", "success");
                    return View();
                }
            }
            TempData["Message"] = Jobs.CreateMessage("HATA", "Profiliniz onaylanırken bir hata oluştu", "danger");
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                TempData["Message"] = Jobs.CreateMessage("HATA!", "Lütfen mail adresinizi yazınızı!", "warning");
            }
            User user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage("HATA!", "Böyle bir kullanıcı bulunamadı! Lütfen kontrol ederek yeniden deneyiniz!", "warning");
                return View();
            }
            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            string url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });
            await _emailSender.SendEmailAsync(
                email,
                "Ozel Ders Şifre Sıfırlama!",
                $"Parolanızı yeniden belirlemek için <a href='http://localhost:5116/{url}'>tıklayınız</a>"
                );
            TempData["Message"] = Jobs.CreateMessage(
               "BİLGİLENDİRME!",
               "Lütfen mail adresinize gelen maili kontrol edip, yönergeleri takip ederek parolanızı yeniden belirlemeyi deneyiniz!",
               "warning");
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["Message"] = Jobs.CreateMessage(
                    "Geçersiz İşlem!",
                    "Beklenmedik bir hata oluştu, lütfen defolun!",
                    "warning");
                return Redirect("/");
            }
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token
            };
            return View(resetPasswordViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid) { return View(resetPasswordViewModel); }
            User user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage(
                   "Hata!",
                   "Kullanıcı bilgisi bulunamadı, lütfen tekrar deneyiniz!",
                   "warning");
                return Redirect("/");
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.Token, resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage(
                   "Başarılı!",
                   "Parolanız, başarıyla değiştirilmiştir! Giriş yapmayı deneyebilirsiniz.",
                   "success");
                return RedirectToAction("Login");
            }
            TempData["Message"] = Jobs.CreateMessage(
                "Bir sorun oluştu!",
                "Beklenmedik bir sorun oluştu",
                "danger");
            return View(resetPasswordViewModel);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
