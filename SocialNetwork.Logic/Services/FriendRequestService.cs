using AutoMapper;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.DTO;
using SocialNetwork.Logic.Exceptions;
using SocialNetwork.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Logic.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FriendRequestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void AcceptRequest(int id)
        {
            var request = _unitOfWork.Requests.GetById(id);
            if(request == null)
            {
                throw new NotFoundException($"Request with id {id} doesn't exist");
            }
            var user1 = _unitOfWork.Users.GetById(request.FromUserId);
            var user2 = _unitOfWork.Users.GetById(request.ToUserId);
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            _unitOfWork.Requests.Delete(request);
            _unitOfWork.Save();
        }

        public IEnumerable<RequestDTO> GetCurrentUserRequest(int currentUserId)
        {
            var requests = _unitOfWork.Requests.GetAll(x => x.AppUser).Where(x => x.ToUserId == currentUserId || x.FromUserId != currentUserId);
            return _mapper.Map<IEnumerable<RequestDTO>>(requests);
        }

        public IEnumerable<UserDTO> GetUserFriends(int currentUserId)
        {
            var friends = _unitOfWork.Users.GetAll(u => u.Friends).SingleOrDefault(x => x.Id == currentUserId).Friends;
            return _mapper.Map<IEnumerable<UserDTO>>(friends);
        }

        public void RejectRequest(int id)
        {
            var request = _unitOfWork.Requests.GetById(id);
            if (request == null)
            {
                throw new NotFoundException($"Request with id {id} doesn't exist");
            }

            _unitOfWork.Requests.Delete(request);
            _unitOfWork.Save();
        }

        public void SendRequest(int toUserId, int fromUserId)
        {
            Request request = new Request()
            {
                FromUserId = fromUserId,
                Date = DateTime.Now,
                ToUserId = toUserId
            };
            _unitOfWork.Requests.Create(request);
            _unitOfWork.Save();
        }

        public int CountFriendRequests(int userId)
        {
            return _unitOfWork.Requests.GetAll().Where(x => x.ToUserId == userId).Count();
        }
    }
}
