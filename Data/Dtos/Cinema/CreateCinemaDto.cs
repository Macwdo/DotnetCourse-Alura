using System.ComponentModel.DataAnnotations;
namespace DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;

public class CreateCinemaDto
{
        [Required(ErrorMessage = "The cinema name is required.")]
        public string Name { get; set; }
        
        public int AddressId { get; set; }
}
