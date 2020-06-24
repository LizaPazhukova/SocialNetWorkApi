using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public PostDTO Post { get; set; }
        public UserDTO AppUser { get; set; }
    }
}
