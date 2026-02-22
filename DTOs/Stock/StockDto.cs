using System.ComponentModel.DataAnnotations;
using DTOs.Comments;
namespace DTOs.Stocks;

public class StockDto
{
    [Required]
    [MaxLength(10,ErrorMessage = "Max length is 10 character")]
    [MinLength(3,ErrorMessage ="Min length is 3 character")]
    public string Symbol { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(1,1000000000)]
    public decimal Purches { get; set; }
    public decimal LastDiv { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    public List<CommentsDto>? Comment { get; set; }
}