using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkEdu_Core_Service.Domain.Entities;

namespace ThinkEdu_Core_Service.Infrastructure.Configurations
{
    public class ToChucEntityTypeConfiguration : BaseEntityTypeConfiguration<ToChuc, long>
    {
        public override void Configure(EntityTypeBuilder<ToChuc> builder)
        {
            builder.ToTable("to_chuc");
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.MaToChuc).HasColumnName("ma_to_chuc").IsRequired().HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.TenToChuc).HasColumnName("ten_to_chuc").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(t => t.Email).HasColumnName("email").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.SoDienThoai).HasColumnName("so_dien_thoai").IsRequired(false).HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(x => x.Status).HasColumnName("status").IsRequired().HasColumnType("varchar(50)").HasMaxLength(50);
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").IsRequired(false);
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").IsRequired(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Ignore(x => x.UpdatedBy);
            builder.Ignore(x => x.DeletedBy);                             
        }
    }
}