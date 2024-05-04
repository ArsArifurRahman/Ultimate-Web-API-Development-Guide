namespace Project.DTOs.Comment;

public class CommentReadDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public int? StockId { get; set; }
}
