using System;
using Data;
using Entities;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class CommentsRepository(AppDbContext db) : ICommentsRepository
{
    public Task<Comments> CreateComments()
    {
        throw new NotImplementedException();
    }

    public Task<Comments> DeleteComments()
    {
        throw new NotImplementedException();
    }

    public Task<List<Comments>> GetAllComments()
    {
        throw new NotImplementedException();
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
