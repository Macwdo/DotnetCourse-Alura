using AutoMapper;
using DOTNET6_COURSE_WEB_API.Models;

namespace DOTNET6_COURSE_WEB_API.Profiles;

public class SessionProfile: Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, ReadSessionDto>();
    }
}