using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal.Repositories
{
    public interface IUserRepository : IRepository<AppUser>
    {
    }
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }
    }
}
