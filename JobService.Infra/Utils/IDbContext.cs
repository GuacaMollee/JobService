namespace JobService.Infra.Utils
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    public interface IDbContext
    {
        int SaveChanges();

        void Dispose();

        DatabaseFacade Database { get; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    }
}
