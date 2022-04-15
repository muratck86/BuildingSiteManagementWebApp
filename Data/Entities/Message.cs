using System;
using System.ComponentModel.DataAnnotations;

namespace BuildingSiteManagementWebApp.Data.Entities
{
    public class Message : BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public bool IsNew { get; set; } = true;
        public DateTime? ReadDate { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

        public string SenderId { get; set; }
        public AppUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public AppUser Receiver { get; set; }
    }
}
