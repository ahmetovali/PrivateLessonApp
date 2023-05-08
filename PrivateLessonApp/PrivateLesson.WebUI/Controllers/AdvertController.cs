using Microsoft.AspNetCore.Mvc;

namespace PrivateLesson.WebUI.Controllers
{
    public class AdvertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
