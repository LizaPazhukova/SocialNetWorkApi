using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public UserDTO AppUser { get; set; }
        public string Text { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public ICollection<LikeDTO> Likes { get; set; }
    }
}
