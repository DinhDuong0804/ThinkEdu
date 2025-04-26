using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ThinkEdu_Core_Service.Domain.Common;
namespace ThinkEdu_Core_Service.Infrastructure.Configurations
{
    public abstract class BaseEntityTypeConfiguration<T, TKey> : IEntityTypeConfiguration<T>
     where T : BaseEntity<TKey>
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}