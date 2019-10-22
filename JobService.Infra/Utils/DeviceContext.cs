namespace JobService.Infra.Utils
{
    using JobService.Infra.Models.DeviceModels;
    using Microsoft.EntityFrameworkCore;

    public class DeviceContext : DbContext, IDbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        { }

        /// <summary>
        /// Get or sets the devices data model
        /// </summary>
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
