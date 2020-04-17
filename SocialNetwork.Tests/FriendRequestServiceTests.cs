using Moq;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SocialNetwork.Tests
{
    public class FriendRequestServiceTests
    {
        //[Fact]
        //public void AcceptRequest_FromOneToOtherUser_RequestAccepted()
        //{
        //    var mockSet = new Mock<IRepository<Request>>();
        //    var mock = new Mock<IUnitOfWork>();
        //    mock.Setup(m => m.Requests).Returns(mockSet.Object);
        //    var friendRequestService = new FriendRequestService(mock.Object);

        //    friendRequestService.AcceptRequest(1);

        //    mockSet.Verify(m => m.Delete(It.Is<Request>(m => m.Id == 1)), Times.Once());
        //    //mock.Verify(m => m.Save(), Times.Once());
        //}
        //private IQueryable<Request> GetTestRequests()
        //{
        //    var requests = new List<Request>
        //    {
        //        new Request { Id=1, FromUserId=1, ToUserId = 2},
        //    };
        //    return requests.AsQueryable();

        //}
        //public void GetUserFriends_UserWithTwoFriends_ReturnTheseFriends()
        //{

        //}

    }
}
