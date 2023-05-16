using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
    [Required(ErrorMessage = "Du måste ange artikelnummer")]
    [Display(Name = "Artikelnummer *")]
    public string ArticleNumber { get; set; } = null!;

    [Required(ErrorMessage = "Du måste ange ett productnamn")]
    [Display(Name = "Productnamn *")]
    public string Name { get; set; } = null!;



    [Display(Name = "Productbeskrivning (valfritt)")]
    public string? Description { get; set; }


    [Required(ErrorMessage = "Du måste ange ett productpris")]
    [Display(Name = "Productpris *")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Produktbild Url (valfritt)")]
    public string? ImageUrl { get; set; }


    public static implicit operator ProductEntity(ProductRegistrationViewModel productRegistrationViewModel)
    {
        return new ProductEntity
        {
            ArticleNumber = productRegistrationViewModel.ArticleNumber,
            Name = productRegistrationViewModel.Name,
            Description = productRegistrationViewModel.Description,
            Price = productRegistrationViewModel.Price,
            ImageUrl = productRegistrationViewModel.ImageUrl
        };
    }
}
