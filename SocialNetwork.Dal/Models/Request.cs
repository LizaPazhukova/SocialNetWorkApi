using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Dal.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("FromUserId")]
        public AppUser AppUser { get; set; }
    }
}
