using Microsoft.AspNetCore.Mvc;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
