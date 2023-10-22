using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaySky.DataAccess.Repository.IRepository;
using PaySky.Models.ApiModels.UserEntity;
using PaySky.Models.Dtos;
using System.Security.Cryptography;
using PaySky.Utility;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace PaySky.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUserRepository _userRepository { get; }
        public IRoleRepository _roleRepository { get; }
        public IConfiguration _configuration { get; }

        public AuthController(IUserRepository userRepository,IRoleRepository roleRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UserDto userDto)
        {
            Encryption.EncryptPassword(userDto.Password,out byte[] PasswordHash,out byte[] PasswordSalt );

            User user = new User();

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.PasswordSalt = PasswordSalt;
            user.PasswordHash = PasswordHash;
            user.role = _roleRepository.GetRole(userDto.Role); 

            _userRepository.Add(user);
            _userRepository.Save();

            var token = CreateToken(user);

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(UserLoginDto userLoginDto)
        {
            var user = _userRepository.Get(u => u.Email.Contains(userLoginDto.Email));

            if (user == null)
            {
                return BadRequest("User Not Found");
            }

            if (!Encryption.CheckPassword(userLoginDto.Password,user.PasswordHash,user.PasswordSalt))
            {
                return BadRequest("Password is incorrect");
            }

            var token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                    new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.role.Name),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        

    }
}
