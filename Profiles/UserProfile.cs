using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data.Dtos.User;
using DOTNET6_COURSE_WEB_API.Models;

namespace DOTNET6_COURSE_WEB_API.Profiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}