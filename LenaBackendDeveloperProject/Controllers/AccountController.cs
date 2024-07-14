using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace LenaBackendDeveloperProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userService.AuthenticateAsync(username, password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }
    }
}
