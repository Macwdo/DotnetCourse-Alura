using AutoMapper;
using DOTNET6_COURSE_WEB_API.Data.Dtos.Cinema;
using DOTNET6_COURSE_WEB_API.Models;

namespace DOTNET6_COURSE_WEB_API.Profiles;

public class AddressProfile: Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();
        CreateMap<ReadAddressDto, Address>();
        CreateMap<Address, ReadAddressDto>();
        CreateMap<UpdateAddressDto, Address>();
    }
    
}