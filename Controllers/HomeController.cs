﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Contexts;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductContext _context;

        public HomeController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var newTagProduct = _context.ProductTags.FirstOrDefault(x => x.TagId == 1);
            var featuredTagProduct = _context.ProductTags.FirstOrDefault(x => x.TagId == 2);
            var popularTagProduct = _context.ProductTags.FirstOrDefault(x => x.TagId == 3);

            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel
                {
                    Title = "New Collection",
                    Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                    GridItems = new List<GridCollectionItemViewModel>()
                },

                UpToSell = new GridCollectionViewModel
                {
                    Title = "Featured Collection",
                    GridItems = new List<GridCollectionItemViewModel>()
                },

                TopSelling = new GridCollectionViewModel
                {
                    Title = "Popular Collection",
                    GridItems = new List<GridCollectionItemViewModel>()
                }
            };

            if (newTagProduct != null)
            {
                viewModel.BestCollection.GridItems = _context.ProductTags
                    .Where(pt => pt.Tag.Id == newTagProduct.TagId)
                    .Select(pt => pt.Product)
                    .Select(p => new GridCollectionItemViewModel
                    {
                        Id = p.ArticleNumber,
                        Title = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl!
                    }).ToList();
            }

            if (featuredTagProduct != null)
            {
                viewModel.UpToSell.GridItems = _context.ProductTags
                    .Where(pt => pt.Tag.Id == featuredTagProduct.TagId)
                    .Select(pt => pt.Product)
                    .Select(p => new GridCollectionItemViewModel
                    {
                        Id = p.ArticleNumber,
                        Title = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl!
                    }).ToList();
            }

            if (popularTagProduct != null)
            {
                viewModel.TopSelling.GridItems = _context.ProductTags
                    .Where(pt => pt.Tag.Id == popularTagProduct.TagId)
                    .Select(pt => pt.Product)
                    .Select(p => new GridCollectionItemViewModel
                    {
                        Id = p.ArticleNumber,
                        Title = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl!
                    }).ToList();
            }

            return View(viewModel);
        }
    }
}
