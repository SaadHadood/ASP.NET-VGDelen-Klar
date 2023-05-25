using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize(Roles ="admin")]
public class AdminController : Controller
{
    private readonly UserService _userService;
    private readonly AuthenticationService _auth;

    public AdminController(UserService userService, AuthenticationService auth)
    {
        _userService = userService;
        _auth = auth;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Users()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Users(string userId, string selectedRole, string action)
    {
        if (action == "delete")
        {
            var success = await _userService.RemoveUser(userId);
            if (success)
            {
                return RedirectToAction("Users");
            }
            else
            {
                return RedirectToAction("Error", "User");
            }
        }
        else
        {
            var success = await _userService.ChangeUserRoleAsync(userId, selectedRole);
            if (success)
            {
                return RedirectToAction("Users");
            }
            else
            {
                return RedirectToAction("Error", "User");
            }
        }
    }

    public IActionResult UserRegister()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UserRegister(AdminUserRegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                ModelState.AddModelError("", "An account with the same email already exists");

            if (await _auth.RegisterAdminUserAsync(viewModel))
                return RedirectToAction("users", "admin");
        }

        return View(viewModel);
    }

}
