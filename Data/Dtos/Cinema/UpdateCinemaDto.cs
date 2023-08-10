using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "The cinema name is required.")]
    public string Name { get; set; }
}