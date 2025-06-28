using System;
using Microsoft.AspNetCore.Identity;

namespace VibesAndChill.Shared.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public string PreferredGender { get; set; }
        public string Location { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public bool IsProfileComplete { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastActive { get; set; }
        public ICollection<UserMatch> Matches { get; set; }
        public ICollection<UserLike> LikedByUsers { get; set; }
        public ICollection<UserLike> LikedUsers { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
    }
}
