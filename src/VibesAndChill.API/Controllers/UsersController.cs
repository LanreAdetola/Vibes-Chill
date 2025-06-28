using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VibesAndChill.Shared.Models;

namespace VibesAndChill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("me")]
        public async Task<ActionResult<AppUser>> GetCurrentUser()
        {
            var username = User.Identity.Name;
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateProfile([FromBody] AppUser updated)
        {
            var username = User.Identity.Name;
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null) return NotFound();

            user.FirstName = updated.FirstName;
            user.LastName = updated.LastName;
            user.Bio = updated.Bio;
            user.Gender = updated.Gender;
            user.PreferredGender = updated.PreferredGender;
            user.Location = updated.Location;
            user.ProfilePhotoUrl = updated.ProfilePhotoUrl;
            user.IsProfileComplete = updated.IsProfileComplete;
            user.DateOfBirth = updated.DateOfBirth;

            await _userManager.UpdateAsync(user);
            return NoContent();
        }
    }
}
