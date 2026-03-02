using System;
using AutoMapper;
using DTOs.Identity;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

public class AccountController(UserManager<AppUser> userManager, IMapper mapper) : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var UserData = mapper.Map<AppUser>(registerDto);
            var CreatedUser = await userManager.CreateAsync(UserData, registerDto.Password);
            if (CreatedUser.Succeeded)
            {
                var role = await userManager.AddToRoleAsync(UserData, "User");
                if (role.Succeeded)
                {
                    return Ok("User created");
                }
                else
                {
                    return StatusCode(500, role.Errors);
                }
            }
            else
            {
                return BadRequest(CreatedUser.Errors);
            }
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }

    }
}
