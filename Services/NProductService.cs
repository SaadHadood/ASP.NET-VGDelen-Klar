using WebApp.Models.Entities;
using WebApp.Repositories;

namespace WebApp.Services;

public class NProductService
{
    private readonly ProductRepository _productRepo;
    private readonly ProductTagRepository _productTagRepo;

    public NProductService(ProductRepository productRepo, ProductTagRepository productTagRepo)
    {
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
    }


    public async Task<bool> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)
                return true;
        }

        return false;
    }

    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    {
        foreach(var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = entity.ArticleNumber,
                TagId = int.Parse(tag)
            });
        }
    }

}
