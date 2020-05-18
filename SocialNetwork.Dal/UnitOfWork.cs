using SocialNetwork.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Dal
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _context;
        private bool _isDisposed;
       
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            
        }
        private IRepository<AppUser> _usersRepository;
        private IRepository<Message> _messagesRepository;
        private IRepository<Post> _postsRepository;
        private IRepository<Request> _requestsRepository;
        private IRepository<Like> _likesRepository;
        private IRepository<Comment> _commentsRepository;

        public IRepository<AppUser> Users
        {
            get
            {
                return _usersRepository ?? (_usersRepository = new RepositoryBase<AppUser>(_context));
            }
        }
        public IRepository<Message> Messages
        {
            get
            {
                return _messagesRepository ?? (_messagesRepository = new RepositoryBase<Message>(_context));
            }
        }

        public IRepository<Post> Posts
        {
            get
            {
                return _postsRepository ?? (_postsRepository = new RepositoryBase<Post>(_context));
            }
        }

        public IRepository<Request> Requests
        {
            get
            {
                return _requestsRepository ??
                       (_requestsRepository = new RepositoryBase<Request>(_context));
            }
        }

        public IRepository<Like> Likes
        {
            get
            {
                return _likesRepository ??
                        (_likesRepository = new RepositoryBase<Like>(_context));
            }
        }
        public IRepository<Comment> Comments
        {
            get
            {
                return _commentsRepository ??
                        (_commentsRepository = new RepositoryBase<Comment>(_context));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _isDisposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
