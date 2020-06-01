using SocialNetwork.Dal.Models;
using SocialNetwork.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<AppUser> Users { get; }
        IRepository<Message> Messages { get; }
        IPostRepository Posts { get; }
        IRepository<Like> Likes { get; }  
        IRepository<Request> Requests { get; }
        IRepository<Comment> Comments { get; }
        void Save();
    }
}
