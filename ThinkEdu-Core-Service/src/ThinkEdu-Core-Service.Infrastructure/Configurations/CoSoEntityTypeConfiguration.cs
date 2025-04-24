using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkEdu_Core_Service.Domain.Entities;

namespace ThinkEdu_Core_Service.Infrastructure.Configurations
{
    public class CoSoEntityTypeConfiguration : BaseEntityTypeConfiguration<CoSo, long>
    {
        public override void Configure(EntityTypeBuilder<CoSo> builder)
        {
            builder.ToTable("co_so");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.MaCoSo).HasColumnName("ma_co_so").IsRequired().HasColumnType("varchar(255)").HasMaxLength(255);
            builder.HasIndex(x => x.MaCoSo).IsUnique();
            builder.Property(x => x.TenCoSo).HasColumnName("ten_co_so").IsRequired().HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.DiaChi).HasColumnName("dia_chi").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.SoDienThoai).HasColumnName("so_dien_thoai").IsRequired(false).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(t => t.Email).HasColumnName("email").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.TrungTamId).HasColumnName("trung_tam_id").IsRequired().HasColumnType("bigint");
            builder.Property(t => t.TenantId).HasColumnName("tenant_id").IsRequired().HasColumnType("bigint");
            builder.Property(x => x.Status).HasColumnName("status").IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.UpdatedBy).HasColumnName("updated_by").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.HasOne(x => x.TrungTam).WithMany(x => x.CoSo).HasForeignKey(x => x.TrungTamId).OnDelete(DeleteBehavior.Cascade);
            builder.Ignore(x => x.DeletedBy);
            builder.Ignore(x => x.DeletedAt);                
        }
    }
}