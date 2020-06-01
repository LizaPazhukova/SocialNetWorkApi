using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public UserDTO AppUser { get; set; }
    }
}
