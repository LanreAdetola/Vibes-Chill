using System;

namespace VibesAndChill.Shared.Models
{
    public class UserMatch
    {
        public string UserId1 { get; set; }
        public string UserId2 { get; set; }
        public DateTime MatchedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        
        public AppUser User1 { get; set; }
        public AppUser User2 { get; set; }
    }
}
