using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(int toUserId, int fromUserId, string messageText);
        IEnumerable<Message> GetUserMessages(int currentUserId);
        IEnumerable<Message> GetUserMessagesWithOneUser(int otherUserId, int curentUserId);
    }
}
