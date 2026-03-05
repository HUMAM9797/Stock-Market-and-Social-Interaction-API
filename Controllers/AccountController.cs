using System;
using AutoMapper;
using Data;
using DTOs.Identity;
using Entities;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers;

public class AccountController(UserManager<AppUser> userManager, IMapper mapper, ITokenGenerateService tokenService, IConfiguration config, SignInManager<AppUser> signInManager) : BaseController
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(s => s.UserName == loginDto.UserName);
        if (user == null) return Unauthorized("Invalid Username");

        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded) return Unauthorized("Username not found and/or password inccorect");

        return Ok(
            new NewUserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                token = tokenService.CreateToken(user, config)
            }
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var UserData = mapper.Map<AppUser>(registerDto);
            var normalizedEmail = registerDto.Email.Trim().ToLower();

            if (await userManager.FindByEmailAsync(normalizedEmail) != null)
                return BadRequest("User already exsist");

            var CreatedUser = await userManager.CreateAsync(UserData, registerDto.Password);
            if (CreatedUser.Succeeded)
            {
                var role = await userManager.AddToRoleAsync(UserData, "User");
                if (role.Succeeded)
                {
                    return Ok(
                        new NewUserDto
                        {
                            UserName = UserData.UserName,
                            Email = UserData.Email,
                            token = tokenService.CreateToken(UserData, config)
                        }
                    );
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
