namespace JobService.Infra.Utils
{
    using Microsoft.EntityFrameworkCore;
    using JobService.Infra.Models.TagModels;

    public class JobTagsContext : DbContext, IDbContext
    {
        public JobTagsContext(DbContextOptions<JobTagsContext> options) : base(options)
        { }

        public DbSet<HangfireJobServiceTags> HangfireJobServiceTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HangfireJobServiceTags>().ToTable("JobServiceTags", "Hangfire")
                .HasKey(contract => new { contract.Id });
        }
    }
}
