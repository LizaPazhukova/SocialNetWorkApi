﻿using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers(SearchUser userSearchParams);
        IEnumerable<UserDTO> SearchedUsers(string name);
        Task<UserDTO> GetUser(int id);

    }
}
