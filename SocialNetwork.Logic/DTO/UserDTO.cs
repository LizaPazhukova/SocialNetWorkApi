using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
        public string City { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public List<PostDTO> Posts { get; set; }
        public List<RequestDTO> Requests { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public List<UserDTO> Friends { get; set; } 
        public List<LikeDTO> Likes { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public byte[] Avatar { get; set; }
    }
}
