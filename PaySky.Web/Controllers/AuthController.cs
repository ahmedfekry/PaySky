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

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto userDto)
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
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Role,user.role.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value
                ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(100),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}
