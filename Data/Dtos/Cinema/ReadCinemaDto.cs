using DOTNET6_COURSE_WEB_API.Models;

namespace DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ReadAddressDto Address { get; set; }
    public ICollection<ReadSessionDto> Sessions { get; set; }

}