using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ContactFormViewModel
{
    [Display(Name = "Your Name*")]
    [Required(ErrorMessage = "Your name is required.")]
    [MinLength(2, ErrorMessage = "Your name must be at least 2 characters long.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é-][a-öA-Ö]+)*$", ErrorMessage = "Du måste ange ett giltig namn")]
    public string Name { get; set; } = null!;

    [Display(Name = "Your Email*")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must provide an e-mail address.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must provide a valid e-mail address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number (optional)")]
    public string? Mobile { get; set; }

    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }

    [Display(Name = "Message*")]
    [MinLength(10, ErrorMessage = "Your message must be at least 10 characters long.")]
    [Required(ErrorMessage = "You must write a message.")]
    public string Message { get; set; } = null!;


    public static implicit operator ContactEntity(ContactFormViewModel viewModel)
    {
        return new ContactEntity
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            Mobil = viewModel.Mobile,
            CompanyName = viewModel.CompanyName,
            Message = viewModel.Message
        };
    }

}

