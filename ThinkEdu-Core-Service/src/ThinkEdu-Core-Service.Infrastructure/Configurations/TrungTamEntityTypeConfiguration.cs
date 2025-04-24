using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkEdu_Core_Service.Domain.Entities;

namespace ThinkEdu_Core_Service.Infrastructure.Configurations
{
    public class TrungTamEntityTypeConfiguration : BaseEntityTypeConfiguration<TrungTam, long>
    {
        public override void Configure(EntityTypeBuilder<TrungTam> builder)
        {
            builder.ToTable("trung_tam");
            builder.Property(t => t.Id).HasColumnName("id");
            builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.TenantId).HasColumnName("tenant_id").IsRequired().HasColumnType("bigint");
            builder.Property(t => t.TenTrungTam).HasColumnName("ten_trung_tam").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.DiaChi).HasColumnName("dia_chi").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.SoDienThoai).HasColumnName("so_dien_thoai").IsRequired(false).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(t => t.Email).HasColumnName("email").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.HinhAnh).HasColumnName("hinh_anh").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.MoTa).HasColumnName("mo_ta").IsRequired(false).HasColumnType("varchar");
            builder.Property(t => t.CoSoMax).HasColumnName("co_so_max").IsRequired(false).HasColumnType("int");
            builder.Property(x => x.Status).HasColumnName("status").IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.UpdatedBy).HasColumnName("updated_by").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.HasOne(x => x.ToChuc).WithMany(x => x.TrungTam).HasForeignKey(x => x.TenantId).OnDelete(DeleteBehavior.Cascade);
            builder.Ignore(x => x.DeletedBy);
            builder.Ignore(x => x.DeletedAt);
        }
    }
}