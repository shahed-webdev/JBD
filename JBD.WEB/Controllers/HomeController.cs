using JBD.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using JBD.ViewModel.Modules.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using JBD.DATA.Enums;
using JBD.DATA.Migrations;

namespace JBD.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                return LocalRedirect(await UserRedirect(user));
            }

            return View();
        }


        //POST: Index
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            var result =
                await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.FindByNameAsync(model.UserName);

                var role = await GetRole(user);
                // Add a claim to the user's identity
                var claims = new List<Claim>
                {
                    new Claim("Email", user.Email),
                    new Claim("Role", role.ToString())
                };
                await _userManager.AddClaimsAsync(user, claims);

                return LocalRedirect(await UserRedirect(user));
            }

            if (result.RequiresTwoFactor)
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, model.RememberMe });

            if (result.IsLockedOut)
                return RedirectToPage("./Lockout");


            ModelState.AddModelError(string.Empty, "Incorrect username or password");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return LocalRedirect(Url.Content($"/Home/index"));
            }
        }

        private async Task<UserRoles> GetRole(IdentityUser user)
        {
            UserRoles role;

            var roles = await _userManager.GetRolesAsync(user);

            if (!roles.Any()) return UserRoles.Unknown;

            return Enum.TryParse<UserRoles>(roles[0], true, out role) ? role : UserRoles.Unknown;
        }

        private async Task<string> UserRedirect(IdentityUser user, string? returnUrl = null)
        {
            if (await _userManager.IsInRoleAsync(user, UserRoles.SuperAdmin.ToString()))
                return returnUrl ?? Url.Content($"/SuperAdmin");
            if (await _userManager.IsInRoleAsync(user, UserRoles.Admin.ToString()))
                return returnUrl ?? Url.Content($"/Admin");
            if (await _userManager.IsInRoleAsync(user, UserRoles.Seller.ToString()))
                return returnUrl ?? Url.Content($"/Seller");

            return returnUrl ?? Url.Content($"/Home/index");
        }
    }
}