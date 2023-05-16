using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class UserLoginViewModel
{

    [Display(Name = "E-mail*")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must provide an e-mail address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password*")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must provide a password.")]
    public string Password { get; set; } = null!;


    [Display(Name = "Please keep me logged in")]
    public bool RememberMe { get; set; } = false;

    public string ReturnUrl { get; set; } = "/";
}
