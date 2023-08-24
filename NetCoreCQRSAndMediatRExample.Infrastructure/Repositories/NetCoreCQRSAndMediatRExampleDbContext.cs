using Microsoft.EntityFrameworkCore;
using NetCoreCQRSAndMediatRExample.Domain.Entities;

namespace NetCoreCQRSAndMediatRExample.Infrastructure.Repositories
{
    public class NetCoreCQRSAndMediatRExampleDbContext : DbContext
    {
        public NetCoreCQRSAndMediatRExampleDbContext(DbContextOptions<NetCoreCQRSAndMediatRExampleDbContext> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetCoreCQRSAndMediatRExampleDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}