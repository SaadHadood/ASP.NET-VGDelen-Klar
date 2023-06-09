﻿namespace WebApp.ViewModels;

public class UserRoleViewModel
{
    public string UserId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? CompanyName { get; set; }
    public string Email { get; set; } = null!;
    public string SelectedRole { get; set; } = null!;
    public List<string> Roles { get; set; } = null!;
}


