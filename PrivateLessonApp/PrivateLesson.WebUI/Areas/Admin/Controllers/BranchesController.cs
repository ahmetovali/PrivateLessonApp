using Microsoft.AspNetCore.Mvc;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    public class BranchesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
