using System.ComponentModel.DataAnnotations;

namespace Project.DTOs.Comment;

public class CommentCreateDto
{
    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 characters")]
    [MaxLength(250, ErrorMessage = "Title cannot be over 250 characters")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MinLength(5, ErrorMessage = "Content must be 5 characters")]
    [MaxLength(250, ErrorMessage = "Content cannot be over 250 characters")]
    public string Description { get; set; } = string.Empty;
}
