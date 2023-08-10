using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Models;

public class CreateSessionDto
{
    [Required]
    public int MovieId { get; set; }
    
    [Required]
    public int CinemaId { get; set; }
}