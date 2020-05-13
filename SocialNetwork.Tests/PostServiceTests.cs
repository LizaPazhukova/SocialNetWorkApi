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
    public class PostServiceTests
    {
        [Fact]
        public void GetPosts_ListWithTwoPosts_ReturnsThem()
        {
            // Arrange
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(repo => repo.Posts.GetAll(x => x.Likes, x => x.AppUser)).Returns(GetTestPosts());
            var postService = new PostService(mock.Object);

            // Act
            var result = postService.GetPosts(2);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(GetTestPosts().Count(), result.Count());
            Assert.Equal(GetTestPosts().Select(x => x.Id), result.Select(x => x.Id));
        }
        private IQueryable<Post> GetTestPosts()
        {
            var posts = new List<Post>
            {
                new Post { Id=1, Text="Post1"},
                new Post { Id=2, Text="Post2"},
            };
            return posts.AsQueryable();

        }
        [Fact]
        public void CreatePost_EmptyDb_AddOnePostToDb()
        {
            var mockSet = new Mock<IRepository<Post>>();
            var mockContext = new Mock<IUnitOfWork>();
            mockContext.Setup(m => m.Posts).Returns(mockSet.Object);
            var service = new PostService(mockContext.Object);

            service.Create(1, "Post");

            mockSet.Verify(m => m.Create(It.Is<Post>(m => m.AppUserId == 1 && m.Text == "Post")), Times.Once());
            mockContext.Verify(m => m.Save(), Times.Once());
        }
        [Fact]
        public void LikePost_EmptyDB_AddedOneLikeToPost()
        {
            var mockSet = new Mock<IRepository<Like>>();
            var mockContext = new Mock<IUnitOfWork>();
            mockContext.Setup(m => m.Likes).Returns(mockSet.Object);
            var service = new PostService(mockContext.Object);

            service.LikePost(1, 1);

            mockSet.Verify(m => m.Create(It.Is<Like>(m => m.UserId == 1 && m.PostId == 1)), Times.Once());
            mockContext.Verify(m => m.Save(), Times.Once());
        }
    }
}
