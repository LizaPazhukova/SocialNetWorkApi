using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers(SearchUser userSearchParams);
        IEnumerable<UserDTO> SearchedUsers(string name);
        UserDTO GetUser(int id);

    }
}
