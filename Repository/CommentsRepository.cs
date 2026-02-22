using Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CommentsRepository(AppDbContext db) : ICommentsRepository
{

    public async Task<Comments> CreateCommentsAsync(Comments commentsModel)
    {
        await db.Comments.AddAsync(commentsModel);
        await db.SaveChangesAsync();
        return commentsModel;
    }

    public async Task<Comments> DeleteCommentsAysnc(Comments commentModel)
    {
        await db.SaveChangesAsync();
        return commentModel;
    }

    public async Task<List<Comments>> GetAllCommentsAsync()
    {
        return await db.Comments.ToListAsync();
    }

    public async Task<Comments?> GetCommentsByIdAysnc(int id)
    {
        return await db.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Comments?> UpdateCommentsAysnc(Comments commentModel)
    {
        await db.SaveChangesAsync();
        return commentModel;
    }
}
