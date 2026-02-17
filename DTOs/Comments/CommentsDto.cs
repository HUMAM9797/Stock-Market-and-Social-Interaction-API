using System;

namespace DTOs.Comments;

public class CommentsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime MyProperty { get; set; }
    public int StockId { get; set; }
}
