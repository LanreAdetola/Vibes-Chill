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
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MessagesController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            var sender = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            var recipient = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == message.RecipientId);
            if (recipient == null) return NotFound();
            if (sender.Id == recipient.Id) return BadRequest("You cannot message yourself");

            var newMessage = new Message
            {
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                Content = message.Content,
                DateSent = DateTime.UtcNow
            };
            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();
            return Ok(newMessage);
        }

        [HttpGet("with/{userId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesWithUser(string userId)
        {
            var currentUserId = _userManager.GetUserId(User);
            var messages = await _context.Messages
                .Where(m => (m.SenderId == currentUserId && m.RecipientId == userId) ||
                             (m.SenderId == userId && m.RecipientId == currentUserId))
                .OrderBy(m => m.DateSent)
                .ToListAsync();
            return messages;
        }
    }
}
