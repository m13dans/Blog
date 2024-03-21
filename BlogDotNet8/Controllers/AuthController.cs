using BlogDotNet8.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogDotNet8.Controllers;

public class AuthController : Controller
{
    private SignInManager<IdentityUser> _signInMangaer;

    public AuthController(SignInManager<IdentityUser> signInManager)
    {
        _signInMangaer = signInManager;
    }

    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVM)
    {
        if (loginVM.UserName is null || loginVM.Password is null)
        {
            return View(loginVM);
        }

        var result = await _signInMangaer.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("UserName", "No Username Exist");
            ModelState.AddModelError("Password", "Password doesn't match");
            return View(loginVM);
        }
        return RedirectToAction("Index", "Panel");
    }
    public async Task<IActionResult> Logout()
    {
        await _signInMangaer.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
