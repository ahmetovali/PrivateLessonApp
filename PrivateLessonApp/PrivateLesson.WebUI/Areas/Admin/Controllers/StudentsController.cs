using Microsoft.AspNetCore.Mvc;

namespace PrivateLesson.WebUI.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
