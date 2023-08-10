using System.ComponentModel.DataAnnotations;
namespace DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;

public class CreateAddressDto
{
        [MinLength(3, ErrorMessage = "The place name must be greater than 3 character")]
        [MaxLength(50, ErrorMessage = "The place name must be less than 50 character")]
        [Required]
        public string Place { get; set; }
    
        [Required]
        public int Number { get; set; }
}
