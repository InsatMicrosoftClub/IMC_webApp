using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryUoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private Dictionary<Type, Object> repositories;

        public UnitOfWork()
        {
            context = new ApplicationDbContext();
            repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T, K> getRepository<T, K>() where T : class
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                repositories[typeof(T)] = new GenericRepository<T, K>(context);
            }
            return (IGenericRepository<T, K>)repositories[typeof(T)];
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}