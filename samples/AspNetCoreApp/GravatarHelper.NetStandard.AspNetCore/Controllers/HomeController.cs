using Microsoft.AspNetCore.Mvc;

namespace GravatarHelper.NetStandard.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
