using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VibesAndChill.API.Services;
using VibesAndChill.Shared.Models;

namespace VibesAndChill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == dto.Username.ToLower()))
                return BadRequest("Username is taken");

            var user = new AppUser
            {
                UserName = dto.Username.ToLower(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                PreferredGender = dto.PreferredGender,
                Location = dto.Location,
                Bio = dto.Bio
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return new AuthResponseDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] RegisterDto dto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == dto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid password");

            return new AuthResponseDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}
