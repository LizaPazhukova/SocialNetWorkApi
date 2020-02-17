using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SocialNetwork.Dal
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] properties);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
