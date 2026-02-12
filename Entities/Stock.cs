using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Stock
{
    public int Id { get; set; }
    public int Sympol { get; set; }
    public string CompanyName { get; set; } =string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Purches { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal LastDiv { get; set; }
    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    public List<Comments> Comment { get; set; } = new List<Comments>();
}
