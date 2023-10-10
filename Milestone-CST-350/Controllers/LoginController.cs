using Microsoft.AspNetCore.Mvc;
using Milestone_CST_350.Models;

namespace Milestone_CST_350.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult processLogin(RegistrationModel user)
        {
            if (user.Username == "root" && user.Password == "root")
            {
                return View("loginSuccess");
            }
            else
            {
                return View("loginFail");
            }
        }
    }
}
