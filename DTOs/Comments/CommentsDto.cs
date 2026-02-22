using System.ComponentModel.DataAnnotations;

namespace DTOs.Comments;

public class CommentsDto
{
    [Required]
    [MinLength(5,ErrorMessage = "Title must be five characters")]
    [MaxLength(280 , ErrorMessage = "Title cannot be over 280 characters")] 
    public string Title { get; set; } = string.Empty;
    [MinLength(5,ErrorMessage = "Content must be five characters")]
    [MaxLength(280 , ErrorMessage = "Content cannot be over 280 characters")] 
    public string Content { get; set; } = string.Empty;
    public DateTime MyProperty { get; set; }
    public int StockId { get; set; }
}
