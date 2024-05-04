using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Repositories.Contracts;

namespace Project.Repositories.Services;

public class CommentService : ICommentContract
{
    private readonly DataContext _context;

    public CommentService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comment>> GetCommentsAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment> GetCommentAsync(int id)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

        if (comment == null)
        {
            throw new InvalidOperationException("Comment not found");
        }

        return comment;
    }

    public async Task<Comment> AddCommentAsync(Comment comment)
    {
        if (comment == null)
        {
            throw new ArgumentNullException(nameof(comment));
        }

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return comment;
    }

    public async Task UpdateCommentAsync(int id, Comment comment)
    {
        if (comment == null)
        {
            throw new ArgumentNullException(nameof(comment));
        }

        var existingComment = await GetCommentAsync(id);

        if (existingComment == null)
        {
            throw new KeyNotFoundException("The existing comment with the given id was not found.");
        }

        _context.Entry(existingComment).CurrentValues.SetValues(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(int id)
    {
        var comment = await GetCommentAsync(id);

        if (comment == null)
        {
            throw new KeyNotFoundException("The comment with the given id was not found.");
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}
