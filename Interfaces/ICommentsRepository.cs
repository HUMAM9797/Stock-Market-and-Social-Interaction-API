using System;
using Entities;


namespace Interfaces;

public interface ICommentsRepository
{
    Task<List<Comments>> GetAllCommentsAsync();
    Task<Comments?> GetCommentsByIdAysnc(int id);
    Task<Comments> CreateComments();
    Task<Comments> UpdateComments();
    Task<Comments> DeleteComments();
}
