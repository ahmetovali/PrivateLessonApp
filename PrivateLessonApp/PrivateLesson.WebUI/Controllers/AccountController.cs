using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Models.ViewModels.AccountModels;

namespace PrivateLesson.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITeacherService _teacherService;
        private readonly IBranchService _branchService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITeacherService teacherService, IBranchService branchService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherService = teacherService;
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel
            {
                Branches = await _branchService.GetBranchesAsync(true)
            };

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName= registerViewModel.FirstName,
                    LastName= registerViewModel.LastName,
                    Gender=registerViewModel.Gender,
                    DateOfBirth=registerViewModel.DateOfBirth,
                    City=registerViewModel.City,
                    Phone=registerViewModel.Phone,
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            }

            return View(registerViewModel);
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
    }
}
