using SocialNetwork.Dal;
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
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<AppUser> GetUsers()
        {
            return _unitOfWork.Users.GetAll();
        }

        public IEnumerable<AppUser> SearchedUsers(string name)
        {
            IEnumerable<AppUser> users;
            if (string.IsNullOrEmpty(name))
            {
                users = _unitOfWork.Users.GetAll().OrderBy(i => i.Id);
            }
            else
            {
                users = _unitOfWork.Users.GetAll().Where(i => i.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).OrderBy(i => i.Id);
            }
            return users;
        }
    }
}
