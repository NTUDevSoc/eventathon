using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class HealthController
{
    [HttpGet("/health")]
    public Task<IActionResult> Get()
    {
        return Task.FromResult(new OkResult() as IActionResult);
    }
}