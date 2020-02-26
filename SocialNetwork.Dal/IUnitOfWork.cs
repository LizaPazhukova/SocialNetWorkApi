using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<AppUser> Users { get; }
        IRepository<Message> Messages { get; }
        IRepository<Post> Posts { get; }
        IRepository<Like> Likes { get; }  
        IRepository<Request> Requests { get; }
        void Save();
    }
}
