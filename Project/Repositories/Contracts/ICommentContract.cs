using Project.Models;

namespace Project.Repositories.Contracts;

public interface ICommentContract
{
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment> GetCommentAsync(int id);
    Task<Comment> AddCommentAsync(Comment comment);
    Task UpdateCommentAsync(int id, Comment comment);
    Task DeleteCommentAsync(int id);
}
