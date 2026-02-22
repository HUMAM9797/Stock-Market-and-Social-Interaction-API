using System.ComponentModel.DataAnnotations;
using DTOs.Comments;
namespace DTOs.Stocks;

public class StockDto
{
    [Required]
    [MaxLength(10,ErrorMessage = "Symbol cannot be over 10 characters")]
    public string Symbol { get; set; } = string.Empty;
    [Required]
    [MaxLength(10,ErrorMessage = "Company Name cannot be over 10 characters")]
    public string CompanyName { get; set; } = string.Empty;
    [Required]
    [Range(1,10000000000000.0)]
    public decimal Purches { get; set; }
    [Range(0.001, 100.0)]
    public decimal LastDiv { get; set; }
    [Required]
    [MaxLength(10, ErrorMessage ="Industry cannot be over 10 characters")]
    public string Industry { get; set; } = string.Empty;
    [Range(1, 5000000000000.0)]
    public long MarketCap { get; set; }
    public List<CommentsDto>? Comment { get; set; }
}