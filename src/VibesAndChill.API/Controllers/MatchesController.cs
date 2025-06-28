using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VibesAndChill.API.Data;
using VibesAndChill.Shared.Models;

namespace VibesAndChill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MatchesController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("like/{username}")]
        public async Task<IActionResult> LikeUser(string username)
        {
            var sourceUser = await _userManager.Users.Include(u => u.LikedUsers).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            var likedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (likedUser == null) return NotFound();
            if (sourceUser.Id == likedUser.Id) return BadRequest("You cannot like yourself");
            if (await _context.Likes.AnyAsync(x => x.SourceUserId == sourceUser.Id && x.LikedUserId == likedUser.Id))
                return BadRequest("You already liked this user");

            var like = new UserLike { SourceUserId = sourceUser.Id, LikedUserId = likedUser.Id };
            _context.Likes.Add(like);

            // Check for match
            if (await _context.Likes.AnyAsync(x => x.SourceUserId == likedUser.Id && x.LikedUserId == sourceUser.Id))
            {
                var match = new UserMatch { UserId1 = sourceUser.Id, UserId2 = likedUser.Id };
                _context.Matches.Add(match);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMatch>>> GetMatches()
        {
            var userId = _userManager.GetUserId(User);
            var matches = await _context.Matches.Where(m => m.UserId1 == userId || m.UserId2 == userId).ToListAsync();
            return matches;
        }
    }
}
