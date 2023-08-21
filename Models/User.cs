using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DOTNET6_COURSE_WEB_API.Models;

public class User: IdentityUser
{
    [Required]
    public bool IsActive { get; set; }
}