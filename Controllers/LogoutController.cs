using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Identity;

namespace WebApp.Controllers;

public class LogoutController : Controller
{

    private readonly SignInManager<AppUser> _sigInManager;

    public LogoutController(SignInManager<AppUser> sigInManager)
    {
        _sigInManager = sigInManager;
    }

    public async Task<IActionResult> Index()
    {
        if(_sigInManager.IsSignedIn(User))
            await _sigInManager.SignOutAsync();

        return LocalRedirect("/");
    }
}
