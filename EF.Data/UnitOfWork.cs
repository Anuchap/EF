using System;
using System.Collections.Generic;

namespace EF.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly EfContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositories;
        private CustomRepository _customRepository;

        public UnitOfWork(EfContext context)
        {
            _context = context;
        }

        public UnitOfWork()
        {
            _context = new EfContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public Repository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)_repositories[type];
        }

        public CustomRepository CustomRepository()
        {
            if (_customRepository == null)
            {
                _customRepository = new CustomRepository(_context);
            }
            return _customRepository;
        }
    }
}