using System;

namespace DTOs.Identity;

public class NewUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string token { get; set; }
}
