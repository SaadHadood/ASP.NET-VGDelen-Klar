using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories
{
    public class ProductTagRepository : ProductRepo<ProductTagEntity>
    {
        public ProductTagRepository(ProductContext productContext) : base(productContext)
        {
        }
    }
}
