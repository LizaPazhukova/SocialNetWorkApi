using System;
using System.Collections.Generic;

namespace SocialNetwork.Dal.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? ParentPostId { get; set; }
        public List<Post> Comments { get; set; } = new List<Post>();
        public List<Like> Likes { get; set; }
    }
}
