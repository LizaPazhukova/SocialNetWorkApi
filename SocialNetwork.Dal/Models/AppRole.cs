using Microsoft.AspNetCore.Identity;


namespace SocialNetwork.Dal.Models
{
    public class AppRole:IdentityRole<int>
    {
        public AppRole() { }
        public AppRole(string name)
        {
            Name = name;
        }

    }
}
