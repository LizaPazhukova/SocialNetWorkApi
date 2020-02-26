using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Dal.Models
{
    public class AppUser : IdentityUser<int>
    {
        [PersonalData, Required, StringLength(20)]
        public string FirstName { get; set; }

        [PersonalData, Required, StringLength(20)]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public List<Post> Posts { get; set; }
        public List<Request> Requests { get; set; }
        [InverseProperty("AppUser")]
        public List<Message> Messages { get; set; }
        public List<AppUser> Friends { get; set; } = new List<AppUser>();
        public List<Like> Likes { get; set; }
   //     public List<Comment> Comments { get; set; }
        public byte[] Avatar { get; set; }
    }
}
