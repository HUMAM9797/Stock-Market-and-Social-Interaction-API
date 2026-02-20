using System;
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

    public Task<Comments> DeleteComments()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Comments>> GetAllCommentsAsync()
    {
        return await db.Comments.ToListAsync();
    }

    public async Task<Comments?> GetCommentsByIdAysnc(int id)
    {
        return await db.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public Task<Comments> UpdateComments()
    {
        throw new NotImplementedException();
    }
}
