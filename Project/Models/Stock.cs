using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models;

public class Stock
{
    public int Id { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Purchase { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal LastDividend { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCapital { get; set; }
    public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
}