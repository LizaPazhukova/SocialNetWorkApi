using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IFriendRequestService
    {
        void SendRequest(int toUserId, int fromUserId);
        IEnumerable<Request> GetCurrentUserRequest(int currentUserId);
        void AcceptRequest(int id);
        void RejectRequest(int id);
        IEnumerable<AppUser> GetUserFriends(int currentUserId);

    }
}
