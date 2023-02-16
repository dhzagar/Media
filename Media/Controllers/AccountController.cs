using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Series.Models;

namespace Media.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password, true, false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
