using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("api/user")]
    public Task<OkResult> GetUser()
    {
        /*  We'd likely return JSON here?
            Might be easier for the Node.JS frontend to handle. */
        return Task.FromResult(new OkResult());
    }
}