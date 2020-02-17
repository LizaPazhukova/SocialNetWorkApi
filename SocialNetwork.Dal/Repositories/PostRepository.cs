using SocialNetwork.Dal.Models;

namespace SocialNetwork.Dal.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }
    }
}
