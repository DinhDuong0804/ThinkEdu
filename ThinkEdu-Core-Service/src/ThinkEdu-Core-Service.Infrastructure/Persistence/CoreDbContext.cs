using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ThinkEdu_Core_Service.Domain.Common;
using ThinkEdu_Core_Service.Domain.Entities;

namespace ThinkEdu_Core_Service.Infrastructure.Persistence
{
    public class CoreDbContext : DbContext
    {
        public DbSet<ToChuc> ToChuc { get; set; }

        public DbSet<TrungTam> TrungTam { get; set; }

        public DbSet<CoSo> CoSo { get; set; }

        public DbSet<Setting> Setting { get; set; }

        public CoreDbContext() { }

        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && !t.IsAbstract &&
                    i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                    typeof(BaseEntity<>).IsAssignableFrom(i.GenericTypeArguments[0]))
            );
        }
    }
}