using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntershipProject.Controllers
{
    [Authorize]
    public class ConferenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RawIndex()
        {
            return View();
        }
    }
}
