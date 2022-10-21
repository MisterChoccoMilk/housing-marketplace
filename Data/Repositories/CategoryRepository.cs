using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.Repositories;

public interface ICategoriesRepository
{
    Task<Category?> GetAsync(int categoryId);
    Task<IReadOnlyList<Category>> GetManyAsync();
    Task CreateAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}

public class CategoriesRepository : ICategoriesRepository
{
    private readonly MarketplaceDbContext _marketplaceDbContext;

    public CategoriesRepository(MarketplaceDbContext marketplaceDbContext)
    {
        _marketplaceDbContext = marketplaceDbContext;
    }

    public async Task<Category?> GetAsync(int categoryId)
    {
        return await _marketplaceDbContext.Categories.FirstOrDefaultAsync(o => o.Id == categoryId);
    }

    public async Task<IReadOnlyList<Category>> GetManyAsync()
    {
        return await _marketplaceDbContext.Categories.ToListAsync();
    }

    public async Task CreateAsync(Category category)
    {
        _marketplaceDbContext.Categories.Add(category);
        await _marketplaceDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _marketplaceDbContext.Categories.Update(category);
        await _marketplaceDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _marketplaceDbContext.Categories.Remove(category);
        await _marketplaceDbContext.SaveChangesAsync();
    }
}