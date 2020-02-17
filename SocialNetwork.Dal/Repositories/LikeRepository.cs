using SocialNetwork.Dal.Models;

namespace SocialNetwork.Dal.Repositories
{
    public interface ILikeRepository : IRepository<Like>
    {
    }
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }
    }
}
