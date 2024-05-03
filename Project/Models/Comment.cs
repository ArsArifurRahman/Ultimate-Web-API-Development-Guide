namespace Project.Models;

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    public int? StockId { get; set; }
    public Stock? Stock { get; set; }
}
