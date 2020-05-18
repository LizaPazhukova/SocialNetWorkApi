using SocialNetwork.Dal;
using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using SocialNetwork.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Logic.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IEnumerable<Post> GetPosts(int userId)
        {
            return _unitOfWork.Posts.GetAll(x => x.Likes, x=>x.AppUser, x=>x.Comments).Where(i=>i.AppUserId==userId).OrderByDescending(x=>x.Date);
        }
        public void Create(int userId, string text)
        {
            Post post = new Post()
            {
                Text = text,
                AppUserId = userId,
                Date = DateTime.Now
            };
            _unitOfWork.Posts.Create(post);
            _unitOfWork.Save();
        }
        public void CreateComment(int id, int userId, string text)
        {
            var post = _unitOfWork.Posts.GetById(id);
            Comment comment = new Comment()
            {
                Text = text,
                AppUserId = userId,
                Date = DateTime.Now,
                PostId = id
            };
            _unitOfWork.Comments.Create(comment);
            post.Comments.Add(comment);
            _unitOfWork.Posts.Update(post);
            _unitOfWork.Save();
        }
        public void LikePost(int userId, int postId)
        {
            var existingLike = _unitOfWork.Likes.GetAll().FirstOrDefault(u => u.UserId == userId && u.PostId == postId);
            if (existingLike == null)
            {
                Like like = new Like()
                {
                    UserId = userId,
                    Date = DateTime.Now,
                    PostId = postId
                };

                _unitOfWork.Likes.Create(like);
            }
            else
            {
                _unitOfWork.Likes.Delete(existingLike);
            }

            _unitOfWork.Save();
        }
    }
}
