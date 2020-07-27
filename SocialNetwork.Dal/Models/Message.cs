using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Dal.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int? FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Body { get; set; }
        public bool isReaded { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey ("FromUserId")]
        public AppUser FromUser { get; set; }
        [ForeignKey("ToUserId")]
        public AppUser ToUser { get; set; }

    }
}
