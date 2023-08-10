using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;
using DOTNET6_COURSE_WEB_API.Models;

namespace DOTNET6_COURSE_WEB_API.Profiles;

public class CinemaProfile: Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<ReadCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(
            dest => dest.Address,
            opt => opt.MapFrom(src => src.Address))
            .ForMember(
                dest => dest.Sessions,
                opt => opt.MapFrom(src => src.Sessions));
            
        CreateMap<UpdateCinemaDto, Cinema>();
    }
    
}