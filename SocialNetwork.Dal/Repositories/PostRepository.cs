using Microsoft.EntityFrameworkCore;
using SocialNetwork.Dal.Models;
using System.Linq;

namespace SocialNetwork.Dal.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        public IQueryable<Post> GetPostsWithComments();
    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }

        public IQueryable<Post> GetPostsWithComments()
        {
            return ApplicationDbContext.Posts.Include(x => x.Likes).Include(x => x.AppUser).Include(x => x.Comments).ThenInclude(x => x.AppUser);
        }
    }
}
