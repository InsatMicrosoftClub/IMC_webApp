using System;

namespace DAL.RepositoryUoW
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose();
        IGenericRepository<T, K> getRepository<T, K>() where T : class;
        void Save();
    }
}
