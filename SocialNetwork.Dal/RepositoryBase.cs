using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SocialNetwork.Dal
{
    public class RepositoryBase<T> : IRepository<T> where T : class
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
        }

        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
        }
        public T GetById(int id)
        {
            return this.ApplicationDbContext.Set<T>().Find(id);
        }
        
    }
}
