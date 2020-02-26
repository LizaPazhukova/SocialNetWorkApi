using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IPostService
    {
        void Create(int userId, string text);
        IEnumerable<Post> GetPosts();
        //void CreateComment(int id, int userId, string text);
        void LikePost(int userId, int postId);
    }
}
