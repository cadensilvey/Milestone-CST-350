using Microsoft.AspNetCore.Mvc;
using Milestone_CST_350.Models;
using Milestone_CST_350.Services;
using System.Security.Permissions;

namespace Milestone_CST_350.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult processRegister(RegistrationModel model)
        {

            SecurityService security = new SecurityService();

            if (security.addUser(model))
            {
                return View("registerSuccess", model);

            }
            else
                return View("Index");
        }
    }
}
