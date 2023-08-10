using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Models;

public class Movie
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(50, ErrorMessage = "Title must be less than 50 characters.")]
    [MinLength(3, ErrorMessage = "Title must be greater than 3 characters.")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Kind is required.")]
    [MaxLength(50, ErrorMessage = "Kind must be less than 50 characters.")]
    [MinLength(3, ErrorMessage = "Kind must be greater than 3 characters.")]
    public string Kind { get; set; }
    
    
    [Required(ErrorMessage = "Duration is required.")]
    [Range(60, 150, ErrorMessage = "The duration of movie must be greater than 60 and less than 150 minutes")]
    public int Duration { get; set; }
    
    public virtual ICollection<Session> Sessions { get; set; }

}