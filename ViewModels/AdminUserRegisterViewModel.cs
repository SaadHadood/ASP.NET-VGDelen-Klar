using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class AdminUserRegisterViewModel
{
    [Display(Name = "First Name*")]
    [Required(ErrorMessage = "You must provide a first name.")]
    [MinLength(2, ErrorMessage = "Your first name must be at least 2 characters long.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltig förnamn")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last Name*")]
    [Required(ErrorMessage = "You must provide a last name.")]
    [MinLength(2, ErrorMessage = "Your last name must be at least 2 characters long.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltig förnamn")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Street Name*")]
    [Required(ErrorMessage = "You must provide a street name.")]
    public string StreetName { get; set; } = null!;


    [Display(Name = "Postal Code*")]
    [Required(ErrorMessage = "You must provide a postal code.")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City*")]
    [Required(ErrorMessage = "You must provide a city name.")]
    public string City { get; set; } = null!;

    [Display(Name = "Mobile (optional)")]
    public string? Mobile { get; set; }

    [Display(Name = "Company (optional)")]
    public string? Company { get; set; }

    [Display(Name = "E-mail*")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must provide an e-mail address.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a valid e-mail address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password*")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must provide a password.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You must provide a valid password.")]
    public string Password { get; set; } = "BytMig123!";

    public bool TermsAndConditions { get; set; } = false;



    // För att slippa göra omvandling i flera ställen så gör jag det här.

    public static implicit operator AppUser(AdminUserRegisterViewModel viewModel)
    {
        return new AppUser
        {
            UserName = viewModel.Email,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.Mobile,
            CompanyName = viewModel.Company
        };
    }


    public static implicit operator AddressEntity(AdminUserRegisterViewModel viewModel)
    {
        return new AddressEntity
        {
            StreetName = viewModel.StreetName,
            PostalCode = viewModel.PostalCode,
            City = viewModel.City
        };
    }
}
