using Weelo.Domain.Entities;
using Weelo.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Weelo.Infrastructure.Context
{
    public class PersistenceContext : DbContext
    {

        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_config.GetValue<string>("SchemaName"));

            modelBuilder.Entity<Owner>();
            modelBuilder.Entity<Property>();
            modelBuilder.Entity<PropertyImage>();
            modelBuilder.Entity<PropertyTrace>();


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var t = entityType.ClrType;
                if (typeof(DomainEntity).IsAssignableFrom(t))
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
