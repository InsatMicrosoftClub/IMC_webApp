using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryUoW
{
    class GenericRepository<T, K> : IDisposable, IGenericRepository<T, K> where T : class
    {
        public readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<T> GetAll()
        {
            IList<T> query = context.Set<T>().ToList<T>();
            return query;
        }

        // Repositored Classes must have an Id property named 'Id'
        public T GetSingle(K Id)
        {
            return context.Set<T>().Find(Id);
            //var query = (from c in context.Set<T>() select c).FirstOrDefault<T>(x => x.Id == Id);
            //return query;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {

            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;

        }

        public void Save()
        {
            context.SaveChanges();
        }

        void IDisposable.Dispose()
        {
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
