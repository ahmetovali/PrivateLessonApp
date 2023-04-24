using Microsoft.AspNetCore.Mvc;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
