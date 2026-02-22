using AutoMapper;
using DTOs.Comments;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

public class CommentsController(ICommentsRepository commentsRepo, IStockRepository stockRepo, IMapper mapper) : BaseController
{
    [HttpGet("{id:int}")]
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
        var CommentsModel = await commentsRepo.GetAllCommentsAsync();
        if (CommentsModel == null)
        {
            return NotFound();
        }
        var CommentsDto = mapper.Map<List<CommentsDto>>(CommentsModel);
        return Ok(CommentsDto);
    }

    [HttpPost("{StockId:int}")]
    public async Task<IActionResult> CreateComments([FromRoute] int StockId, CreateCommentsDto commentsDto)
    {
        if (!await stockRepo.StockExisit(StockId))
        {
            return BadRequest("there is no such stock");
        }
        var CommentModel = mapper.Map<Comments>(commentsDto);
        CommentModel.StockId = StockId;
        await commentsRepo.CreateCommentsAsync(CommentModel);
        return CreatedAtAction(nameof(GetCommentsById), new { id = CommentModel.Id }, mapper.Map<CommentsDto>(CommentModel));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateComments([FromRoute] int id, UpdateCommentsDto commentsDto)
    {
        var CommentsModel = await commentsRepo.GetCommentsByIdAysnc(id);
        if (CommentsModel == null)
        {
            return NotFound();
        }
        mapper.Map(commentsDto, CommentsModel);
        await commentsRepo.UpdateCommentsAysnc(CommentsModel);
        return Ok(mapper.Map<UpdateCommentsDto>(CommentsModel));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteComments([FromRoute] int id)
    {
        var CommentsModel = await commentsRepo.GetCommentsByIdAysnc(id);
        if (CommentsModel == null)
        {
            return NotFound();
        }
        CommentsModel.IsDeleted = true;
        await commentsRepo.DeleteCommentsAysnc(CommentsModel);
        return NoContent();
    }
}
