using Moq;
using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using SocialNetwork.Logic.Services;

namespace SocialNetwork.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GetUsers_FromListWithUsers_ReturnTheseUsers()
        {
            // Arrange 
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(repo => repo.Users.GetAll()).Returns(GetTestUsers());
            var userService = new UserService(mock.Object);

            // Act
            var result = userService.GetUsers();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(GetTestUsers().Count(), result.Count());
            Assert.Equal(GetTestUsers().Select(x => x.Id), result.Select(x => x.Id));
        }
        private IQueryable<AppUser> GetTestUsers()
        {
            var users = new List<AppUser>
            {
                new AppUser { Id=1, FirstName="Tom"},
                new AppUser { Id=2, FirstName="Alice"},
            };
            return users.AsQueryable();
        }
        [Fact]
        public void SearchUser_FromListWithUsers_ReturnThisUser()
        {
            // Arrange 
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(repo => repo.Users.GetAll()).Returns(GetTestUsers());
            var userService = new UserService(mock.Object);

            // Act
            string name = "Tom";
            var result = userService.SearchedUsers("Tom");

            // Assert
            Assert.NotEmpty(result);
            Assert.All(result, x => x.FirstName.Contains(name));
            
        }
    }
}
