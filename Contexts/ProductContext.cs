using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions <ProductContext> options) : base(options)
    {
    }


    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }

}
