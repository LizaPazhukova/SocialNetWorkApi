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
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FriendRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void AcceptRequest(int id)
        {
            var request = _unitOfWork.Requests.GetById(id);
            var user1 = _unitOfWork.Users.GetById(request.FromUserId);
            var user2 = _unitOfWork.Users.GetById(request.ToUserId);
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            _unitOfWork.Requests.Delete(request);
            _unitOfWork.Save();
        }

        public IEnumerable<Request> GetCurrentUserRequest(int currentUserId)
        {
            return _unitOfWork.Requests.GetAll(x => x.AppUser).Where(x => x.ToUserId == currentUserId || x.FromUserId != currentUserId);
        }

        public IEnumerable<AppUser> GetUserFriends(int currentUserId)
        {
            var user = _unitOfWork.Users.GetAll(u => u.Friends).SingleOrDefault(x => x.Id == currentUserId);
            return user.Friends;
        }

        public void RejectRequest(int id)
        {
            var request = _unitOfWork.Requests.GetById(id);
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
    }
}
