using System;
using Entities;


namespace Interfaces;

public interface ICommentsRepository
{
    Task<List<Comments>> GetAllCommentsAsync();
    Task<Comments?> GetCommentsByIdAysnc(int id);
    Task<Comments> CreateCommentsAsync(Comments commentsModel);
    Task<Comments> UpdateComments();
    Task<Comments> DeleteComments();
    
}
