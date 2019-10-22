namespace JobService.Infra.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public interface IRepository<T, Tcontext>
        where T : class 
        where Tcontext : DbContext
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>Entity</returns>
        T Get<TKey>(TKey id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets all. With data pagination.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageCount">The page count.</param>
        /// <returns></returns>
        IQueryable<T> GetAll(int page, int pageCount);

        /// <summary>
        ///     <para>
        ///         Creates a LINQ query based on a raw SQL query.
        ///     </para>
        ///     <para>
        ///         If the database provider supports composing on the supplied SQL, you can compose on top of the raw SQL query using
        ///         LINQ operators - <code>context.Blogs.FromSql("SELECT * FROM dbo.Blogs").OrderBy(b =&gt; b.Name)</code>.
        ///     </para>
        ///     <para>
        ///         As with any API that accepts SQL it is important to parameterize any user input to protect against a SQL injection
        ///         attack. You can include parameter place holders in the SQL query string and then supply parameter values as additional
        ///         arguments. Any parameter values you supply will automatically be converted to a DbParameter -
        ///         <code>context.Blogs.FromSql("SELECT * FROM [dbo].[SearchBlogs]({0})", userSuppliedSearchTerm)</code>.
        ///     </para>
        ///     <para>
        ///         You can also construct a DbParameter and supply it to as a parameter value. This allows you to use named
        ///         parameters in the SQL query string -
        ///         <code>context.Blogs.FromSql("SELECT * FROM [dbo].[SearchBlogs]({@searchTerm})", new SqlParameter("@searchTerm", userSuppliedSearchTerm))</code>
        ///     </para>
        /// </summary>
        /// <param name="sql"> The raw SQL query. </param>
        /// <param name="parameters"> The values to be assigned to parameters. </param>
        /// <returns>List of entities</returns>
        Task<List<T>> FromSqlAsync(string sql, params object[] parameters);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The Entity's state</returns>
        EntityState Add(T entity);

        /// <summary>
        /// Deletes the specified <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        /// <returns>The Entity's state</returns>
        EntityState Delete(T entity);

        /// <summary>
        /// Checks whether a entity matching the <paramref name="predicate"/> exists
        /// </summary>
        /// <param name="predicate">The predicate to filter on</param>
        /// <returns>Whether an entity matching the <paramref name="predicate"/> exists</returns>
        bool Exists(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The Entity's state</returns>
        EntityState Update(T entity);

        /// <summary>
        /// Execute query like a stored percedure
        /// </summary>
        /// <param name="query">SQL Query</param>
        /// <param name="parameters">parameters in the SQL Query</param>
        /// <returns></returns>
        Task<int> ExecuteQuery(string query, params object[] parameters);
    }
}
