using ThinkEdu_Core_Service.Domain.Common;

namespace ThinkEdu_Core_Service.Domain.Entities
{
    public class ToChuc : BaseAuditableEntity<long>
    {
        public string MaToChuc { get; set; } = null!;

        public string? TenToChuc { get; set; }

        public string? Email { get; set; }

        public string? SoDienThoai { get; set; }

        public ICollection<Setting>? Setting { get; set; } = new List<Setting>();

        public ICollection<TrungTam>? TrungTam { get; set; } = new List<TrungTam>();

    }
}