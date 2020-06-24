using SocialNetwork.Dal.Models;
using SocialNetwork.Logic.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Logic.Interfaces
{
    public interface IPostService
    {
        PostDTO Create(int userId, string text);
        IEnumerable<PostDTO> GetPosts(int userId);
        void CreateComment(int id, int userId, string text);
        void LikePost(int userId, int postId);
        void Delete(int id);
    }
}
