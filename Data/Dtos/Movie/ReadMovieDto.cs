namespace DOTNET6_COURSE_WEB_API.Models;

public class ReadMovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public string Kind { get; set; }
    
    public int Duration { get; set; }

    public DateTime requestedDay { get; set; } = DateTime.Now;
    
    public ICollection<ReadSessionDto> Sessions { get; set; }

}