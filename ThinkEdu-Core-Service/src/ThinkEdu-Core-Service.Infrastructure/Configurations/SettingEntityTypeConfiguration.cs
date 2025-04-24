using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkEdu_Core_Service.Domain.Entities;

namespace ThinkEdu_Core_Service.Infrastructure.Configurations
{
    public class SettingEntityTypeConfiguration : BaseEntityTypeConfiguration<Setting, long>
    {
        public override void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.ToTable("setting");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.SettingKey).HasColumnName("setting_key").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(e => e.SettingValue).HasColumnName("setting_value").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(e => e.TenantId).HasColumnName("tenant_id").IsRequired().HasColumnType("bigint");
            builder.HasOne(e => e.ToChuc).WithMany(tc => tc.Setting).HasForeignKey(e => e.TenantId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
