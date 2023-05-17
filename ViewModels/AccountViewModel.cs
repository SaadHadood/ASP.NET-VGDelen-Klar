using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class AccountViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? CompanyName { get; set; }
    public string? Mobil { get; set; }
}
