using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public UserDTO FromUser { get; set; }
        public UserDTO ToUser { get; set; }
    }
}
