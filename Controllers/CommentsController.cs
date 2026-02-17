using System;
using AutoMapper;
using DTOs.Comments;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

public class CommentsController(ICommentsRepository commentsRepo, IMapper mapper) : BaseController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentsById([FromRoute] int id)
    {
        var CommentsModel = await commentsRepo.GetCommentsByIdAysnc(id);
        if (CommentsModel == null)
        {
            return NotFound();
        }
        var commentsDto = mapper.Map<CommentsDto>(CommentsModel);
        return Ok(commentsDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var CommentsModel = commentsRepo.GetAllCommentsAsync();
        if (CommentsModel == null)
        {
            return NotFound();
        }
        var CommentsDto = mapper.Map<List<CommentsDto>> (CommentsModel);
        return Ok(CommentsDto);
    }
}
