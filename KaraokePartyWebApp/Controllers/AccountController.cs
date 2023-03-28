using KaraokePartyWebApp.Data;
using KaraokePartyWebApp.Models;
using KaraokePartyWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KaraokePartyWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var userFound = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (userFound != null)
            {
                var passwordIsCorrect = await _userManager.CheckPasswordAsync(userFound, loginViewModel.Password);
                if (passwordIsCorrect)
                {
                    var signIn = await _signInManager.PasswordSignInAsync(userFound, loginViewModel.Password, false, false);
                    if (signIn.Succeeded)
                    {
                        return RedirectToAction("Index", "KaraokeGroup");
                    }
                }
                //Password is incorrect
                TempData["Error"] = "Não encontramos um usuário com estas credenciais, tente novamente";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Não encontramos um usuário com estas credenciais, tente novamente";
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Este endereço de email já está em uso";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction("Index","KaraokeGroup");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","KaraokeGroup");
        }
    }
}

