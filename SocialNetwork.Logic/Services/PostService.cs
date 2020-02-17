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
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;
        public PostService(IPostRepository postRepository, ILikeRepository likeRepository)
        {
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.GetAll(x => x.Comments,x => x.Likes, x=>x.AppUser).Where(x=>x.ParentPostId == null);
        }
        public void Create(int userId, string text)
        {
            Post post = new Post()
            {
                Text = text,
                AppUserId = userId,
                Date = DateTime.Now
            };
            _postRepository.Create(post);
        }
        public void CreateComment(int id, int userId, string text)
        {
            var post = _postRepository.GetById(id);
            post.Comments.Add(new Post()
            {
                Text = text,
                AppUserId = userId,
                Date = DateTime.Now,
                ParentPostId = id
            });
            _postRepository.Update(post);
        }
        public void LikePost(int userId, int postId)
        {
            var existingLike = _likeRepository.GetAll().FirstOrDefault(u => u.UserId == userId && u.PostId == postId);
            if (existingLike == null)
            {
                Like like = new Like()
                {
                    UserId = userId,
                    Date = DateTime.Now,
                    PostId = postId
                };
            
                _likeRepository.Create(like);
            }
            else
            {
                _likeRepository.Delete(existingLike);
            }

        }
    }
}
