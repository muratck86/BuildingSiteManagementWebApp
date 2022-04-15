using System;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Message : BaseEntity
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public bool IsNew { get; set; } = true;
        public DateTime? ReadDate { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

        public int SenderId { get; set; }
        public AppUser Sender { get; set; }
        public int ReceiverId { get; set; }
        public AppUser Receiver { get; set; }
    }
}
