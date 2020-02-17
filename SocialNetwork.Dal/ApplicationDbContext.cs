using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Dal.Models;

namespace SocialNetwork.Dal
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().Ignore(e => e.FullName);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
