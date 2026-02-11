namespace asp.net_youtube_course.Entities;

public class Comments
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime MyProperty { get; set; }
    public int StockId { get; set; }
    public Stock? Stock { get; set; }

}