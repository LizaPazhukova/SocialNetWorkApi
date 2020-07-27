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
    public class PostServiceTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostService _postService;
        private IMapper _mapper;
        public PostServiceTests()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = new Mapper(config);
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(m => m.Posts.GetAll(x => x.Likes, x => x.AppUser)).Returns(GetTestPosts());
            _postService = new PostService(_mockUnitOfWork.Object, _mapper);
        }
        [Fact]
        public void GetPosts_ListWithTwoPosts_ReturnsThem()
        {
            // Arrange
            int userId = 2;
            var expectedResult = GetTestPosts();
            _mockUnitOfWork.Setup(m => m.Posts.GetPostsWithComments()).Returns(GetTestPosts());

            // Act
            var result = _postService.GetPosts(userId);

            // Assert
            result.Should().NotBeEmpty();
            result.Count().Should().Be(expectedResult.Count());
            result.Select(x => x.Id).Should().Equal(expectedResult.Select(x => x.Id));
        }
        private IQueryable<Post> GetTestPosts()
        {
            var posts = new List<Post>
            {
                new Post { Id=1, Text="Post1", AppUserId = 2},
                new Post { Id=2, Text="Post2", AppUserId = 2},
            };
            return posts.AsQueryable();

        }
        [Fact]
        public void CreatePost_EmptyDb_AddOnePostToDb()
        {
            int userId = 1;
            string text = "Post";

            _postService.Create(userId, text);

            _mockUnitOfWork.Verify(m => m.Posts.Create(It.Is<Post>(m => m.AppUserId == userId && m.Text == text)), Times.Once());
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once());
        }
        [Fact]
        public void LikePost_EmptyDB_AddedOneLikeToPost()
        {
            int userId = 1;
            int postId = 1;
            _mockUnitOfWork.Setup(m => m.Likes.GetAll()).Returns(Enumerable.Empty<Like>().AsQueryable());

            _postService.LikePost(userId, postId);

            _mockUnitOfWork.Verify(m => m.Likes.Create(It.Is<Like>(m => m.UserId == userId && m.PostId == postId)), Times.Once());
            _mockUnitOfWork.Verify(m => m.Save(), Times.Once());
        }
    }
}
