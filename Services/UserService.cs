using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IEnumerable<UserRoleViewModel>> GetUsersWithRolesAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var result = new List<UserRoleViewModel>();

        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var viewModel = new UserRoleViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                CompanyName = user.CompanyName,
                Email = user.Email!,
                Roles = userRoles.ToList()
            };
            result.Add(viewModel);
        }

        return result;
    }
}


