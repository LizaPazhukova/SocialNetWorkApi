using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal.Repositories
{
    public interface IMessageRepository: IRepository<Message>
    {
    }
    public class MessageRepository:RepositoryBase<Message>,IMessageRepository
    {
        public MessageRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        { }
    }
}
