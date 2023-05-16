using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    public class ProductRepository : ProductRepo<ProductEntity>
    {
        public ProductRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
