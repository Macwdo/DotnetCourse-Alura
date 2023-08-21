using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Data.Dtos.User;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
    
    [Required]
    [DefaultValue(true)]
    public bool IsActive { get; set; }
    
}