using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.Dal
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this.ApplicationDbContext = applicationDbContext;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            var query = this.ApplicationDbContext.Set<T>() as IQueryable<T>;

            if (properties == null)
                return query.AsNoTracking();

            return properties.Aggregate(query, (current, property) => current.Include(property));
        }

        public void Create(T entity)
        {
            this.ApplicationDbContext.Set<T>().Add(entity);
            ApplicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
            ApplicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
            ApplicationDbContext.SaveChanges();
        }
        public T GetById(int id)
        {
            return this.ApplicationDbContext.Set<T>().Find(id);
        }
    }
}
