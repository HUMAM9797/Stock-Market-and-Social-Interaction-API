namespace DTOs.Stock;

public class CreateStockDto
{
    public bool IsDeleted { get; set; } = false;
    public int Sympol { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public decimal Purches { get; set; }
    public decimal LastDiv { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
}