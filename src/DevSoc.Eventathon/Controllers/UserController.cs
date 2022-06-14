using DevSoc.Eventathon.Data;
using DevSoc.Eventathon.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet("api/users/{id}")]
    public Task<OkResult> GetUser([FromRoute] string id)
    {
        /*  We'd likely return JSON here?
            Might be easier for the Node.JS frontend to handle. */
        return Task.FromResult(new OkResult());
    }
    
    
    [HttpPost("api/login")]
    public async Task<IActionResult> LoginUser([FromBody] UserDefinition definition)
    {
        Console.WriteLine("Login:\n" + definition.Username + definition.Password);
        return Ok(definition);
    }
    
    [HttpPost("api/users")]
    public async Task<IActionResult> CreateUser([FromBody] UserDefinition definition)
    {
        // This is just commented out to test the api while the servers not working for me (Evelyn)
        /*var userId = await _usersService.CreateUser(definition);
        return Ok(userId);*/
        
        Console.WriteLine("Signup:\n" + definition.Username + definition.Password);
        return Ok(definition);
    }
}