using System;
using asp.net_youtube_course.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class AppUser : IdentityUser
{
    public List<Portfolio>? Portfolios { get; set; }
}
