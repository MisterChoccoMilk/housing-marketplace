using marketplace.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Data.Repositories;

public interface ICommentsRepository
{
    Task<Comment?> GetAsync(int adId, int commentId);
    Task<IReadOnlyList<Comment>> GetManyAsync(int adId);
    Task CreateAsync(Comment comment);
    Task UpdateAsync(Comment comment);
    Task DeleteAsync(Comment comment);
}

public class CommentsRepository : ICommentsRepository
{
    private readonly MarketplaceDbContext _marketplaceDbContext;

    public CommentsRepository(MarketplaceDbContext marketplaceDbContext)
    {
        _marketplaceDbContext = marketplaceDbContext;
    }

    public async Task<Comment?> GetAsync(int adId, int commentId)
    {
        return await _marketplaceDbContext.Comments.FirstOrDefaultAsync(o => o.AdId == adId && o.Id == commentId);
    }

    public async Task<IReadOnlyList<Comment>> GetManyAsync(int adId)
    {
        return await _marketplaceDbContext.Comments.Where(o => o.AdId == adId).ToListAsync(); ////??????????????
    }

    public async Task CreateAsync(Comment comment)
    {
        _marketplaceDbContext.Comments.Add(comment);
        await _marketplaceDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Comment comment)
    {
        _marketplaceDbContext.Comments.Update(comment);
        await _marketplaceDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Comment comment)
    {
        _marketplaceDbContext.Comments.Remove(comment);
        await _marketplaceDbContext.SaveChangesAsync();
    }
}