namespace JobService.Infra.Utils
{
    using Microsoft.EntityFrameworkCore;
    using JobService.Infra.Factories;
    using JobService.Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : DbContext
    {
        private T dbContext;

        private Dictionary<Type, object> repositories;

        public UnitOfWork(IContextFactory<T> contextFactory)
        {
            this.dbContext = contextFactory.DbContext;
        }

        public IRepository<TEntity, T> GetRepository<TEntity>()
            where TEntity : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!this.repositories.ContainsKey(type))
            {
                this.repositories[type] = new Repository<TEntity, T>(this.dbContext);
            }

            return (IRepository<TEntity, T>)this.repositories[type];
        }


        public T Context
        {
            get
            {
                return (T)dbContext;
            }
        }

        public Task<int> Commit()
        {
            return this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
