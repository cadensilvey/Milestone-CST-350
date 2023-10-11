using Microsoft.AspNetCore.Mvc;
using Milestone_CST_350.Models;
using Milestone_CST_350.Services;

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
            SecurityService security = new SecurityService();

            if(security.isValid(user))
            {
                return View("loginSuccess", user);
            }
            else
                return View("loginFail", user);
        }
    }
}
