using AutoMapper;
using DOTNET6_COURSE_WEB_API.Models;

namespace DOTNET6_COURSE_WEB_API.Profiles;

public class MovieProfile: Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(dest => dest.Sessions,
                opt => opt.MapFrom( src => src.Sessions));
        CreateMap<ReadMovieDto, Movie >();
        CreateMap<UpdateMovieDto, Movie>();
    }
}