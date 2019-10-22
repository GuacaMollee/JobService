namespace JobService.Infra.Utils
{
    using Microsoft.EntityFrameworkCore;
    using JobService.Infra.Repositories;
    using System.Threading.Tasks;

    public interface IUnitOfWork<T> where T : DbContext
    {
        T Context { get; }

        IRepository<TEntity, T> GetRepository<TEntity>() where TEntity : class;

        Task<int> Commit();
    }
}
