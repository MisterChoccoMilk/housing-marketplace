using Microsoft.AspNetCore.Mvc;
using marketplace.Data.Dtos;
using marketplace.Data.Entities;
using marketplace.Data.Repositories;

namespace marketplace.Controllers;

[ApiController]
[Route("api/categories/{categoryId}/ads/{adId}/comments")]
public class CommentsController : ControllerBase
{
    private readonly IAdsRepository _adsRepository;
    private readonly ICommentsRepository _commentsRepository;
    public CommentsController(IAdsRepository adsRepository, ICommentsRepository commentsRepository)
    {
        _adsRepository = adsRepository;
        _commentsRepository = commentsRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<CommentDto>> GetMany(int adId)
    {
        var comments = await _commentsRepository.GetManyAsync(adId);
        return comments.Select(o => new CommentDto(o.Id, o.Name, o.Message));
    }

    [HttpGet]
    [Route("{commentId}")]
    public async Task<ActionResult<CommentDto>> Get(int adId, int commentId)
    {
        var comment = await _commentsRepository.GetAsync(adId, commentId);
        // 404
        if (comment == null)
            return NotFound();

        return Ok(new CommentDto(comment.Id, comment.Name, comment.Message));
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> Create(int categoryId, int adId, CreateCommentDto createCommentDto)
    {
        var ad = await _adsRepository.GetAsync(categoryId, adId);
        if (ad == null) return NotFound($"Couldn't find a ad with id of {adId}");

        var comment = new Comment { Name = createCommentDto.Name, Message = createCommentDto.Message };
        comment.AdId = adId;

        await _commentsRepository.CreateAsync(comment);

        return Created("", new CommentDto(comment.Id, comment.Name, comment.Message));
    }

    [HttpPut]
    [Route("{commentId}")]
    public async Task<ActionResult<CommentDto>> Update(int categoryId, int adId, int commentId, UpdateCommentDto updateCommentDto)
    {
        var ad = await _adsRepository.GetAsync(categoryId, adId);
        // 404
        if (ad == null)
            return NotFound($"Couldn't find a ad with id of {adId}");

        var comment = await _commentsRepository.GetAsync(adId, commentId);
        // 404
        if (comment == null)
            return NotFound();

        comment.Message = updateCommentDto.Message;
        await _commentsRepository.UpdateAsync(comment);

        return Ok(new CommentDto(comment.Id, comment.Name, comment.Message));
    }

    [HttpDelete]
    [Route("{commentId}")]
    public async Task<ActionResult> Remove(int adId, int commentId)
    {
        var comment = await _commentsRepository.GetAsync(adId, commentId);
        // 404
        if (comment == null)
            return NotFound();

        await _commentsRepository.DeleteAsync(comment);

        //204
        return NoContent();
    }
}