using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateLesson.Business.Abstract;
using PrivateLesson.Entity.Concrete.Identity;
using PrivateLesson.WebUI.Models.ViewModels;

namespace PrivateLesson.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly INotyfService _notyfService;

        public CartController(UserManager<User> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, INotyfService notyfService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.Id,
                    AdvertId = ci.AdvertId,
                    TeacherName = ci.Advert.Teacher.User.FirstName + ci.Advert.Teacher.User.LastName,
                    ItemPrice = ci.Advert.Price,
                    TeacherGraduation = ci.Advert.Teacher.Graduation,
                    TeacherUrl = ci.Advert.Teacher.Url,
                    TeacherBranch = ci.Advert.Teacher.TeacherBranches.Select(tb => tb.Branch).ToList(),
                    Description = ci.Advert.Description,
                    Amount = ci.Amount,
                    ImageUrl = ci.Advert.Teacher.User.Image.Url
                }).ToList()
            };
            return View(cartViewModel);
        }


        [HttpPost]
        public IActionResult AddToCart(int Id, int Amount)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId, Id, Amount);
            _notyfService.Success("Ders sepetinize başarıyla eklenmiştir");
            return RedirectToAction("Index");
        }
    }
}
