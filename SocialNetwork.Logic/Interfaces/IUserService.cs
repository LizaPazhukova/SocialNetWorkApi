using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetUsers(SearchUser userSearchParams);
        IEnumerable<AppUser> SearchedUsers(string name);
        AppUser GetUser(int id);

    }
}
