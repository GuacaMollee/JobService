namespace JobService.Infra.Utils
{
    using Microsoft.EntityFrameworkCore;

    public class ClientContext : DbContext, IDbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }
    }
}
