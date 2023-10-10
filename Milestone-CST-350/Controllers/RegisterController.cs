using Microsoft.AspNetCore.Mvc;
using Milestone_CST_350.Models;

namespace Milestone_CST_350.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult processRegister (RegistrationModel model)
        {
            return View("registerSuccess");
        }
    }
}
