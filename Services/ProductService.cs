using WebApp.Models.Entities;
using WebApp.Models;
using WebApp.ViewModels;
using WebApp.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services;

public class ProductService
{
    private readonly ProductContext _context;

    public ProductService(ProductContext context)
    {
        _context = context;
    }


    public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
            ProductEntity productEntity = productRegistrationViewModel;

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }


    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.ToListAsync();
        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }
        return products;
    }

    public async Task<ProductModel> GetByIdAsync(string id)
    {
        var productEntity = await _context.Products.FindAsync(id);
        if (productEntity == null)
        {
            return null!;
        }
        return productEntity;
    }
}
