using System;
using Entities;
using Services;

namespace Interfaces;

public interface ITokenGenerateService
{
    string CreateToken(AppUser user, IConfiguration config);
}
