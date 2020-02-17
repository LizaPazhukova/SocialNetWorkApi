using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<AppUser> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public IEnumerable<AppUser> SearchedUsers(string name)
        {
            IEnumerable<AppUser> users;
            if (string.IsNullOrEmpty(name))
            {
                users = _userRepository.GetAll().OrderBy(i => i.Id);
            }
            else
            {
                users = _userRepository.GetAll().Where(i => i.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).OrderBy(i => i.Id);
            }
            return users;
        }
    }
}
