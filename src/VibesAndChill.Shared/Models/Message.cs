using System;

namespace VibesAndChill.Shared.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public string RecipientId { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; } = DateTime.UtcNow;
        public DateTime? DateRead { get; set; }
        public bool IsRead { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
        
        public AppUser Sender { get; set; }
        public AppUser Recipient { get; set; }
    }
}
