using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Models;

public class Session
{
     [Required]
     public int? MovieId { get; set; }
     public virtual Movie Movie { get; set; }
     
     public int? CinemaId { get; set; }
     public virtual Cinema Cinema { get; set; }
}