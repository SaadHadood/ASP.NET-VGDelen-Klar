using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

[Authorize(Roles ="admin")]
public class AdminController : Controller
{
    private readonly UserService _userService;

    public AdminController(UserService userService)
    {
        _userService = userService;
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


}
