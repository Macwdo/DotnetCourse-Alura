using System.ComponentModel.DataAnnotations;

namespace DOTNET6_COURSE_WEB_API.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "The cinema name is required.")]
    public string Name { get; set; }
    
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    
    public virtual ICollection<Session> Sessions { get; set; }
}