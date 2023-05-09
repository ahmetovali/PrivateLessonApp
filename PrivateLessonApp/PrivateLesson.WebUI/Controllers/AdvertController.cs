using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Core;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.Entity.Concrete;
using PrivateLesson.WebUI.Models.ViewModels.AdvertModels;

namespace PrivateLesson.WebUI.Controllers
{
    public class AdvertController : Controller
    {
        private IAdvertService _advertService;
        private ITeacherService _teacherService;
        private UserManager<User> _userManager;

        public AdvertController(IAdvertService advertService, ITeacherService teacherService, UserManager<User> userManager)
        {
            _advertService = advertService;
            _teacherService = teacherService;
            _userManager = userManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(AdvertListViewModel advertListViewModel)
        {
            List<Advert> advertList;
            if (advertListViewModel.Adverts == null)
            {
                var userId = _userManager.GetUserId(User);
                var teacher = _teacherService.GetTeacherFullDataStringAsync(userId);
                advertList = await _advertService.GetAdvertsFullDataAsync(userId, advertListViewModel.ApprovedStatus);
                List<AdvertViewModel> adverts = new List<AdvertViewModel>();
                foreach (var advert in advertList)
                {
                    adverts.Add(new AdvertViewModel
                    {
                        Id = advert.Id,
                        FirstName = advert.Teacher.User.FirstName,
                        LastName = advert.Teacher.User.LastName,
                        CreatedDate = advert.CreatedDate,
                        UpdatedDate = advert.UpdatedDate,
                        IsApproved = advert.IsApproved,
                        Graduation = advert.Teacher.Graduation,
                        Price = advert.Price,
                        Description = advert.Description,
                        Url = advert.Url,
                        Teacher = advert.Teacher,
                        Image = advert.Teacher.User.Image
                    });
                }
                advertListViewModel.Adverts = adverts;
            }
            return View(advertListViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);
            Teacher teacher = await _teacherService.GetTeacherFullDataStringAsync(userId);
            AdvertAddViewModel advertAddViewModel = new AdvertAddViewModel()
            {
                Teacher = teacher,
                TeacherId = teacher.Id
            };

            return View(advertAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertAddViewModel advertAddViewModel)
        {
            var userId = _userManager.GetUserId(User);
            Teacher teacher = await _teacherService.GetTeacherFullDataStringAsync(userId);
            if (ModelState.IsValid)
            {
                Advert advert = new Advert()
                {
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    Price = advertAddViewModel.Price,
                    Description = advertAddViewModel.Description,
                    TeacherId = teacher.Id,
                    Teacher = teacher,
                    Url = Jobs.GetUrl(advertAddViewModel.Description)
                };
                await _advertService.CreateAsync(advert);
                return RedirectToAction("Index");
            }
            return View(advertAddViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Advert deletedAdvert = await _advertService.GetByIdAsync(id);
            if (deletedAdvert != null)
            {
                _advertService.Delete(deletedAdvert);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Advert advert = await _advertService.GetByIdAsync(id);
            AdvertUpdateViewModel advertUpdateViewModel = new AdvertUpdateViewModel()
            {
                Id = advert.Id,
                Price = advert.Price,
                Description = advert.Description,
                UpdatedDate = advert.UpdatedDate,
                IsApproved = advert.IsApproved
            };

            return View(advertUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdvertUpdateViewModel advertUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Advert advert = await _advertService.GetByIdAsync(advertUpdateViewModel.Id);
                advert.Id = advertUpdateViewModel.Id;
                advert.Price = advertUpdateViewModel.Price;
                advert.Description = advertUpdateViewModel.Description;
                advert.UpdatedDate = DateTime.Now;
                advert.IsApproved = true;
                _advertService.Update(advert);

                return RedirectToAction("Index");
            }
            return View(advertUpdateViewModel);
        }
    }
}
