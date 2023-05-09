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

        public override async Task BeforeUpdate(Core.Entities.User entity)
        {
            entity.DateModified = DateTime.Now;
        }

        public override async Task BeforeInsert(UserInsertRequest insert, Core.Entities.User entity)
        {
            var salt = GenerateSalt();
            var hash = GenerateHash(salt, insert.Password);
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

            if (user == null || await VerifyPassowrd(loginDetails.Password, user) == false)
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

        public static async Task<bool> VerifyPassowrd(string password, Core.Entities.User user)
        {
            var hash = GenerateHash(user.PasswordSalt, password);
            if (hash == user.PasswordHash)
                return true;
            else
                return false;
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
