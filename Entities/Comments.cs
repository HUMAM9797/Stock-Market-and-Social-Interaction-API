using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

[Table("Comments")]
public class Comments
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime MyProperty { get; set; }
    public int StockId { get; set; }
    public Stock? Stock { get; set; }
}