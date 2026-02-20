using System;

namespace DTOs.Comments;

public class CreateCommentsDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
