using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Dal.Models
{
    public class AppUser : IdentityUser<int>
    {
        [PersonalData, Required, StringLength(20)]
        public string FirstName { get; set; }

        [PersonalData, Required, StringLength(20)]
        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Phone { get; set; }
        public string City { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }

        public List<Post> Posts { get; set; }
        public List<Request> Requests { get; set; }
        [InverseProperty("FromUser")]
        public List<Message> Messages { get; set; }
        public List<AppUser> Friends { get; set; } = new List<AppUser>();
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public byte[] Avatar { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
