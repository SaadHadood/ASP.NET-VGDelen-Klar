using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly TagService _tagService;
    private readonly NProductService _nproductService;

    public ProductsController(ProductService productService, TagService tagService, NProductService nproductService)
    {
        _productService = productService;
        _tagService = tagService;
        _nproductService = nproductService;
    }




    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();

        var viewModel = new ProductsIndexViewModel
        {
            All = new GridCollectionViewModel
            {
                Title = "All Products",
                Categories = new List<string> { "New", "Popular", "Featured" },
                GridItems = products.Select(p => new GridCollectionItemViewModel
                {
                    Id = p.ArticleNumber!,
                    Title = p.Name!,
                    Price = p.Price!.Value,
                    ImageUrl = p.ImageUrl!
                })
            }
        };

        return View(viewModel);
    }


    public async Task<IActionResult> Register()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {

            if(await _nproductService.CreateAsync(productRegistrationViewModel))
            {
                await _nproductService.AddProductTagsAsync(productRegistrationViewModel, tags);
                return RedirectToAction("Index", "Products");
            }
               
            ModelState.AddModelError("", "Något gick fel vid skapanded av produkten");
            
        }

        ViewBag.Tags = _tagService.GetTagsAsync(tags);
        return View(productRegistrationViewModel);
    }


    public async Task<IActionResult> Details(string id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

}
