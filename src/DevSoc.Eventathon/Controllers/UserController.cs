﻿using DevSoc.Eventathon.Data;
using DevSoc.Eventathon.Data.Security;
using DevSoc.Eventathon.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSoc.Eventathon.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IAuthenticationService _authenticationService;

    public UserController(IUsersService usersService, IAuthenticationService authenticationService)
    {
        _usersService = usersService;
        _authenticationService = authenticationService;
    }

    [HttpGet("api/users/{id}")]
    public Task<OkResult> GetUser([FromRoute] string id)
    {
        // todo: get user
        return Task.FromResult(new OkResult());
    }
    
    
    [HttpPost("api/login")]
    public async Task<IActionResult> LoginUser([FromBody] UserDefinition definition)
    {
        if (string.IsNullOrEmpty(definition.Username) || string.IsNullOrEmpty(definition.Password))
        {
            // todo: add proper validation later
            return BadRequest();
        }
        
        var authenticationResult = await _authenticationService.Authenticate(definition.Username, definition.Password);
        return authenticationResult.IsSuccess ? Ok(authenticationResult.Jwt) : Unauthorized();
    }
    
    [HttpPost("api/users")]
    public async Task<IActionResult> CreateUser([FromBody] UserDefinition definition)
    {
        var userId = await _usersService.CreateUser(definition);
        return Ok(userId);
    }
}