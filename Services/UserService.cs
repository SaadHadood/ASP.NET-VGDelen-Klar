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
                UserId = user.Id,
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


    public async Task<bool> ChangeUserRoleAsync(string userId, string newRole)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return false;
        }

        var existingRoles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, existingRoles);
        if (!result.Succeeded)
        {
            return false;
        }

        result = await _userManager.AddToRoleAsync(user, newRole);
        if (!result.Succeeded)
        {
            return false;
        }

        return true;


    }

    public async Task<bool> RemoveUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user != null)
        {
           var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
        return false;
    }





}


