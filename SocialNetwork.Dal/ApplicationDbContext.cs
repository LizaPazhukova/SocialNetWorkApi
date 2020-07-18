using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialNetwork.Dal.Models;
using System.Threading.Tasks;

namespace SocialNetwork.Dal
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>, IPersistedGrantDbContext
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options)
        {
            _operationalStoreOptions = operationalStoreOptions;
        }

        private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;

        /// <summary>
        /// Gets or sets the <see cref="DbSet{PersistedGrant}"/>.
        /// </summary>
        public DbSet<PersistedGrant> PersistedGrants { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{DeviceFlowCodes}"/>.
        /// </summary>
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

        Task<int> IPersistedGrantDbContext.SaveChangesAsync() => base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            //string adminRoleName = "admin";
            //string userRoleName = "user";
            //string moderatorRoleName = "moderator";

            //string adminEmail = "lizapazhukova@gmail.com";
            //string adminPassword = "1994LizaPazh!";

            //// добавляем роли
            //AppRole adminRole = new AppRole { Id = 1, Name = adminRoleName };
            //AppRole userRole = new AppRole { Id = 2, Name = userRoleName };
            //AppRole moderatorRole = new AppRole { Id = 3, Name = moderatorRoleName };
            //AppUser adminUser = new AppUser { Id = 1, Email = adminEmail };

            //builder.Entity<AppRole>().HasData(new AppRole[] { adminRole, userRole });
            //modelBuilder.Entity<User>().HasData(new User[] { adminUser });
           

            base.OnModelCreating(builder);
            builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
            builder.Entity<AppUser>().Ignore(e => e.FullName);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
