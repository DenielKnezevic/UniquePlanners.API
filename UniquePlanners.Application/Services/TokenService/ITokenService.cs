﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UniquePlanners.Application.Services.TokenService
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> BuildToken(IEnumerable<Claim> claims, SigningCredentials credentials);
    }
}
