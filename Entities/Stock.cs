using System.ComponentModel.DataAnnotations.Schema;
using asp.net_youtube_course.Entities;

namespace Entities;

[Table("Stocks")]
public class Stock
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Symbol { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Purches { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal LastDiv { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    public List<Comments>? Comments { get; set; }
    public List<Portfolio>? Portfolios { get; set; }
}
