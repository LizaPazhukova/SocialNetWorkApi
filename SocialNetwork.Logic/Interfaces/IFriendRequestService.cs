using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IFriendRequestService
    {
        void SendRequest(int toUserId, int fromUserId);
        IEnumerable<RequestDTO> GetCurrentUserRequest(int currentUserId);
        void AcceptRequest(int id);
        void RejectRequest(int id);
        IEnumerable<UserDTO> GetUserFriends(int currentUserId);
        int CountFriendRequests(int userId);
    }
}
