using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        //public int PostId { get; set; }
        //public Post Post { get; set; }
     //   public int AppUserId { get; set; }
      //  public AppUser AppUser { get; set; }
    }
}
