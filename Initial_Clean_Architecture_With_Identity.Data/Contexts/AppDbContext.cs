using Initial_Clean_Architecture_With_Identity.Domain.DbConfigs.Extensions;
using Initial_Clean_Architecture_With_Identity.Domain.Entities;
using Initial_Clean_Architecture_With_Identity.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Initial_Clean_Architecture_With_Identity.Data.Contexts
{

    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            DbConfigExtension.InstallDbConfig(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateModificationDate();

            return (base.SaveChangesAsync(true, cancellationToken));
        }

        private void UpdateModificationDate()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                   .Where(x =>
                                   typeof(IModificationDate).IsAssignableFrom(x.Entity.GetType())
                                   && !x.Entity.GetType().IsInterface
                                   && !x.Entity.GetType().IsAbstract &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

            foreach (var entity in selectedEntityList)
                ((IModificationDate)entity.Entity).ModificationDate = DateTime.UtcNow;
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Test> Tests { get; set; }

    }
}
