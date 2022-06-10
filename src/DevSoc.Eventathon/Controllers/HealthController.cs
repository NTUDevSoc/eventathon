﻿using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class HealthController 
{
    [HttpGet("api/health")]
    public Task<OkResult> GetHealth()
    {
        return Task.FromResult(new OkResult());
    }
}
