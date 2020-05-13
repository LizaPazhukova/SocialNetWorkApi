using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.DTO
{
    public class SearchUser
    {
        public string Name { get; set; }
        public Gender? Gender { get; set; }
        public string City { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
    }
}
