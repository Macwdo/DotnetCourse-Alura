using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [MinLength(3, ErrorMessage = "The place name must be greater than 3 character")]
    [MaxLength(50, ErrorMessage = "The place name must be less than 50 character")]
    [Required]
    public string Place { get; set; }
    
    [Required]
    public int Number { get; set; }
    
    public virtual Cinema Cinema { get; set; }
    
}