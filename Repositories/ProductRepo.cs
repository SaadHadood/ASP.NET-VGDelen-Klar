using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;

namespace WebApp.Repositories;

public abstract class ProductRepo<TEntity> where TEntity : class
{
    private readonly ProductContext _productContext;

    protected ProductRepo(ProductContext productContext)
    {
        _productContext = productContext;
    }

    //Spara till database
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _productContext.Set<TEntity>().Add(entity);
        await _productContext.SaveChangesAsync();
        return entity;
    }


    //Hämta från database
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var item = await _productContext.Set<TEntity>().FirstOrDefaultAsync(expression);
            return item!;
        }
        catch { return null!; }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        try
        {
            var items = await _productContext.Set<TEntity>().ToListAsync();
            return items!;
        }
        catch { return null!; }

    }


    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var items = await _productContext.Set<TEntity>().Where(expression).ToListAsync();
            return items!;
        }
        catch { return null!; }
    }


    // Update
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            _productContext.Set<TEntity>().Update(entity);
            await _productContext.SaveChangesAsync();
            return entity;
        }
        catch { return null!; }
    }


    //Delete
    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        try
        {
            _productContext.Set<TEntity>().Remove(entity);
            await _productContext.SaveChangesAsync();
            return true;
        }
        catch { return false; }

    }
}
