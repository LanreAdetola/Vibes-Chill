using System;

namespace VibesAndChill.Shared.Models
{
    public class UserLike
    {
        public string SourceUserId { get; set; }
        public string LikedUserId { get; set; }
        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
        
        public AppUser SourceUser { get; set; }
        public AppUser LikedUser { get; set; }
    }
}
