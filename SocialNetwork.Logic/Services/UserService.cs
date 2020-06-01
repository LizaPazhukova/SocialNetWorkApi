using AutoMapper;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.DTO;
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
        private IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public UserDTO GetUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }
        public IEnumerable<UserDTO> GetUsers(SearchUser userSearchParams)
        {
            IEnumerable<AppUser> users = _unitOfWork.Users.GetAll().ToList();
            if (!string.IsNullOrEmpty(userSearchParams.Name))
            {
                users = users.Where(u => u.FullName.ToLower().Contains(userSearchParams.Name.ToLower()));
            }
            if (!string.IsNullOrEmpty(userSearchParams.Gender.ToString()))
            {
                users = users.Where(u => u.Gender==userSearchParams.Gender);
            }
            if (!string.IsNullOrEmpty(userSearchParams.City))
            {
                users = users.Where(u => u.City.ToLower().Contains(userSearchParams.City.ToLower()));
            }
            if (userSearchParams.MinAge != null || userSearchParams.MaxAge != null)
            {
                users = users.Where(u=>u.BirthDate.HasValue && Math.Abs(u.BirthDate.Value.Year-DateTime.Today.Year) >= userSearchParams.MinAge && Math.Abs(u.BirthDate.Value.Year - DateTime.Today.Year) <= userSearchParams.MaxAge);
            }
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public IEnumerable<UserDTO> SearchedUsers(string name)
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
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
