using Microsoft.AspNetCore.Mvc;

namespace EFCoreInMemoryDemo.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
