using DOTNET6_COURSE_WEB_API.Data.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET6_COURSE_WEB_API.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{

    [HttpPost]
    public IActionResult NewUser(CreateUserDto userDto)
    {
        throw new NotImplementedException();
    }
    
}