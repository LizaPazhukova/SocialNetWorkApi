using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetUsers();
        IEnumerable<AppUser> SearchedUsers(string name);
        AppUser GetUser(int id);

    }
}
