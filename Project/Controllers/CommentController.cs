using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.DTOs.Comment;
using Project.Models;
using Project.Repositories.Contracts;

namespace Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICommentContract _commentContract;
    private readonly IStockContract _stockContract;

    public CommentController(IMapper mapper, ICommentContract commentContract, IStockContract stockContract)
    {
        _mapper = mapper;
        _commentContract = commentContract;
        _stockContract = stockContract;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentReadDto>>> GetComments()
    {
        return Ok(_mapper.Map<IEnumerable<CommentReadDto>>(await _commentContract.GetCommentsAsync()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDetailDto>> GetComment(int id)
    {
        var comment = await _commentContract.GetCommentAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CommentDetailDto>(comment));
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> PostComment(int stockId, CommentCreateDto createDto)
    {
        if (!await _stockContract.StockExistsAsync(stockId))
        {
            return BadRequest("Stock does not exist.");
        }

        var createComment = new Comment
        {
            Title = createDto.Title,
            Description = createDto.Description,
            StockId = stockId
        };

        var comment = await _commentContract.AddCommentAsync(createComment);
        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutComment(int id, CommentUpdateDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return BadRequest();
        }

        var comment = _mapper.Map<Comment>(updateDto);

        try
        {
            await _commentContract.UpdateCommentAsync(id, comment);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStock(int id)
    {
        try
        {
            await _commentContract.DeleteCommentAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
