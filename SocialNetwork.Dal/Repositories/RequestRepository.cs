using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal.Repositories
{
    public interface IRequestRepository : IRepository<Request>
    {
    }
    public class RequestRepository : RepositoryBase<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }
    }
}
