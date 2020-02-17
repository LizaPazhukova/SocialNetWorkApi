using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Logic.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IUserRepository _userRepository;
        public FriendRequestService(IRequestRepository requestRepository, IUserRepository userRepository)
        {
            _requestRepository = requestRepository;
            _userRepository = userRepository;
        }


        public void AcceptRequest(int id)
        {
            var request = _requestRepository.GetById(id);
            var user1 = _userRepository.GetById(request.FromUserId);
            var user2 = _userRepository.GetById(request.ToUserId);
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            _requestRepository.Delete(request); 
        }

        public IEnumerable<Request> GetCurrentUserRequest(int currentUserId)
        {
            return _requestRepository.GetAll(x => x.AppUser).Where(x => x.ToUserId == currentUserId || x.FromUserId != currentUserId);
        }

        public IEnumerable<AppUser> GetUserFriends(int currentUserId)
        {
            var user = _userRepository.GetAll(u => u.Friends).SingleOrDefault(x => x.Id == currentUserId);
            return user.Friends;
        }

        public void RejectRequest(int id)
        {
            var request = _requestRepository.GetById(id);
            _requestRepository.Delete(request);
        }

        public void SendRequest(int toUserId, int fromUserId)
        {
            Request request = new Request()
            {
                FromUserId = fromUserId,
                Date = DateTime.Now,
                ToUserId = toUserId
            };
            _requestRepository.Create(request);
        }
    }
}
