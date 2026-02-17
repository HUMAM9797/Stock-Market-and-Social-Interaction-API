using System;
using Entities;


namespace Interfaces;

public interface ICommentsRepository
{
    Task<List<Comments>> GetAllComments();
    Task<Comments> GetCommentsByIdAysnc(int id);
    Task<Comments> CreateComments();
    Task<Comments> UpdateComments();
    Task<Comments> DeleteComments();
}
