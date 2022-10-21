using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.Repositories;

public interface IAdsRepository
{
    Task<Ad?> GetAsync(int categoryId, int adId);
    Task<IReadOnlyList<Ad>> GetManyAsync(int categoryId);
    Task CreateAsync(Ad ad);
    Task UpdateAsync(Ad ad);
    Task DeleteAsync(Ad ad);
}

public class AdsRepository : IAdsRepository
{
    private readonly MarketplaceDbContext _marketplaceDbContext;

    public AdsRepository(MarketplaceDbContext marketplaceDbContext)
    {
        _marketplaceDbContext = marketplaceDbContext;
    }

    public async Task<Ad?> GetAsync(int categoryId, int adId)
    {
        return await _marketplaceDbContext.Ads.FirstOrDefaultAsync(o => o.CategoryId == categoryId && o.Id == adId);
    }

    public async Task<IReadOnlyList<Ad>> GetManyAsync(int categoryId)
    {
        return await _marketplaceDbContext.Ads.Where(o => o.CategoryId == categoryId).ToListAsync();
    }

    public async Task CreateAsync(Ad ad)
    {
        _marketplaceDbContext.Ads.Add(ad);
        await _marketplaceDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ad ad)
    {
        _marketplaceDbContext.Ads.Update(ad);
        await _marketplaceDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Ad ad)
    {
        _marketplaceDbContext.Ads.Remove(ad);
        await _marketplaceDbContext.SaveChangesAsync();
    }
}