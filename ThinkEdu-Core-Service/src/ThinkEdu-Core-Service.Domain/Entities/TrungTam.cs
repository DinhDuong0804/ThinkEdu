using ThinkEdu_Core_Service.Domain.Common;

namespace ThinkEdu_Core_Service.Domain.Entities
{
    public class TrungTam : BaseAuditableEntity<long>
    {
        public string? UserId { get; set; }

        public long TenantId { get; set; }

        public ToChuc ToChuc { get; set; } = null!;

        public string? TenTrungTam { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }

        public string? Email { get; set; }

        public string? HinhAnh { get; set; }

        public string? MoTa { get; set; }

        public int? CoSoMax { get; set; }

        public ICollection<CoSo> CoSo { get; set; } = new List<CoSo>();
    }
}