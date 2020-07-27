using AutoMapper;
using FluentAssertions;
using Moq;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.Interfaces;
using SocialNetwork.Logic.MappingProfiles;
using SocialNetwork.Logic.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SocialNetwork.Tests
{
    public class FriendRequestServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IFriendRequestService _friendService;
        private IMapper _mapper;
        public FriendRequestServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = new Mapper(config);
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(m => m.Requests.GetAll(x => x.AppUser)).Returns(GetTestRequests());
            _friendService = new FriendRequestService(_mockUnitOfWork.Object, _mapper);
        }

        [Fact]
        public void AcceptRequest_FromOneToOtherUser_RequestAccepted()
        {
            var requestId = 1;
            var fromUserId = 1;
            var toUserId = 2;
            _mockUnitOfWork.Setup(m => m.Requests.GetById(requestId)).Returns(new Request() { Id = requestId, FromUserId = fromUserId, ToUserId = toUserId });
            _mockUnitOfWork.Setup(m => m.Users.GetById(fromUserId)).Returns(new AppUser() { Id = fromUserId});
            _mockUnitOfWork.Setup(m => m.Users.GetById(toUserId)).Returns(new AppUser() { Id = toUserId });

            _friendService.AcceptRequest(requestId);

            _mockUnitOfWork.Verify(m => m.Requests.Delete(It.Is<Request>(m => m.Id == 1)), Times.Once());
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once());
        }

        [Fact]
        public void GetRequests_ByUserId_RequestsFetched()
        {
            int userId = 2;
            var expectedRequestsCount = 2;

            var requests = _friendService.GetCurrentUserRequest(userId);

            requests.Count().Should().Be(expectedRequestsCount);            
        }
        private IQueryable<Request> GetTestRequests()
        {
            var requests = new List<Request>
            {
                new Request { Id=1, FromUserId = 1, ToUserId = 2},
                new Request { Id=2, FromUserId = 3, ToUserId = 2},
            };
            return requests.AsQueryable();
        }
    }
}
