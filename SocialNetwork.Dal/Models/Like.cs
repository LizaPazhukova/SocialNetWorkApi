using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime Date { get; set; }
        public AppUser AppUser { get; set; }
        public Post Post { get; set; }
    }
}
