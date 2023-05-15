using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniquePlanners.Application.Dto.UserDto;
using UniquePlanners.Application.Services.Base;
using UniquePlanners.Application.Services.Helpers;
using UniquePlanners.Application.Services.TokenService;
using UniquePlanners.Application.Services.UserService.Dto;
using UniquePlanners.Infrastructure.Persistance;

namespace UniquePlanners.Application.Services.UserService
{
    public class UserService : CRUDService<User, Core.Entities.User,UserSearchObject,UserInsertRequest,UserUpdateRequest>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public UserService(ApplicationDbContext db, IMapper mapper, IConfiguration configuration, ITokenService service):base(db,mapper)
        {
            _configuration = configuration;
            _tokenService = service;
        }

        public override Task<User> Insert(UserInsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
                throw new Exception("Password does not match!");

            var entity = base.Insert(request);

            return entity;
        }

        public override Task<User> Update(UserUpdateRequest request, object id)
        {
            if (request.Password != request.PasswordConfirmation)
                throw new Exception("Password does not match!");

            var entity = base.Update(request, id);

            return entity;
        }

        public override async Task BeforeInsert(UserInsertRequest insert, Core.Entities.User entity)
        { 
            await base.BeforeInsert(insert, entity);

            var salt = PasswordHelper.GenerateSalt();
            var hash = PasswordHelper.GenerateHash(salt, insert.Password);
            entity.PasswordSalt = salt;
            entity.PasswordHash = hash;
        }

        public override IQueryable<Core.Entities.User> AddInclude(IQueryable<Core.Entities.User> entity, UserSearchObject search)
        {
            if (search.IncludeRoles.HasValue && search.IncludeRoles == true)
            {
                entity = entity.Include(x => x.UserRoles).ThenInclude(x => x.Role);
            }

            if (search.IncludePlanners.HasValue && search.IncludePlanners == true)
            {
                entity = entity.Include(x => x.Planners);
            }

            return entity;
        }

        public override IQueryable<Core.Entities.User> AddFilter(IQueryable<Core.Entities.User> entity, UserSearchObject search)
        {
            entity = base.AddFilter(entity, search);

            if(string.IsNullOrWhiteSpace(search.FirstName) == false)
            {
                entity = entity.Where(x => x.FirstName.ToLower().StartsWith(search.FirstName.ToLower()));
            }

            if (string.IsNullOrWhiteSpace(search.LastName) == false)
            {
                entity = entity.Where(x => x.LastName.ToLower().StartsWith(search.LastName.ToLower()));
            }

            if (string.IsNullOrWhiteSpace(search.Username) == false)
            {
                entity = entity.Where(x => x.Username.ToLower().StartsWith(search.Username.ToLower()));
            }

            return entity;
        }

        public async Task<string> Login(LoginDto loginDetails)
        {
            var user = _db.Users.Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefault(x => x.Username == loginDetails.Username);

            if (user == null || await PasswordHelper.VerifyPassowrd(loginDetails.Password, user) == false)
                throw new Exception("Username or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("Id", user.Id.ToString())
            };

            claims.AddRange(user.UserRoles.Select(ur => new Claim(ClaimTypes.Role, ur.Role.RoleName)));

            var token = await _tokenService.BuildToken(claims, credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
