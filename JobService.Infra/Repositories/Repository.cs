namespace JobService.Infra.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using JobService.Infra.Utils;

    public class Repository<Tobject, Tcontext> : IRepository<Tobject, Tcontext> 
        where Tobject : class 
        where Tcontext : DbContext
    {
        /// <summary>
        /// EF data base context
        /// </summary>
        private readonly Tcontext context;

        /// <summary>
        /// Used to query and save instances of
        /// </summary>
        private readonly DbSet<Tobject> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(Tcontext context)
        {
            this.context = context;

            this.dbSet = context.Set<Tobject>();
        }

        /// <inheritdoc />
        public virtual EntityState Add(Tobject entity)
        {
            return this.dbSet.Add(entity).State;
        }

        /// <inheritdoc />
        public Tobject Get<TKey>(TKey id)
        {
            return this.dbSet.Find(id);
        }

        /// <inheritdoc />
        public async Task<Tobject> GetAsync<TKey>(TKey id)
        {
            return await this.dbSet.FindAsync(id);
        }

        /// <inheritdoc />
        public Tobject Get(params object[] keyValues)
        {
            return this.dbSet.Find(keyValues);
        }

        /// <inheritdoc />
        public IQueryable<Tobject> FindBy(Expression<Func<Tobject, bool>> predicate)
        {
            return this.dbSet.Where(predicate);
        }

        /// <inheritdoc />
        public IQueryable<Tobject> FindBy(Expression<Func<Tobject, bool>> predicate, string include)
        {
            return this.FindBy(predicate).Include(include);
        }

        /// <inheritdoc />
        public IQueryable<Tobject> GetAll()
        {
            return this.dbSet;
        }

        public IQueryable<Tobject> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;

            return this.dbSet.Skip(pageSize).Take(pageCount);
        }

        /// <inheritdoc />
        public IQueryable<Tobject> GetAll(string include)
        {
            return this.dbSet.Include(include);
        }

        /// <inheritdoc />
        public IQueryable<Tobject> GetAll(string include, string include2)
        {
            return this.dbSet.Include(include).Include(include2);
        }

        /// <inheritdoc />
        public bool Exists(Expression<Func<Tobject, bool>> predicate)
        {
            return this.dbSet.Any(predicate);
        }

        /// <inheritdoc />
        public EntityState Delete(Tobject entity)
        {
            return this.dbSet.Remove(entity).State;
        }

        /// <inheritdoc />
        public virtual EntityState Update(Tobject entity)
        {
            return this.dbSet.Update(entity).State;
        }

        public async Task<List<Tobject>> FromSqlAsync(string sql, params object[] parameters)
        {
            return await this.dbSet.FromSql(sql, parameters).ToListAsync();
        }

        public Task<int> ExecuteQuery(string query, params object[] parameters)
        {
            return context.Database.ExecuteSqlCommandAsync(query, parameters);
        }
    }
}
