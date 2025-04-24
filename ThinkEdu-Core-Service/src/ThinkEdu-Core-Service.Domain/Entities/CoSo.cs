using ThinkEdu_Core_Service.Domain.Common;

namespace ThinkEdu_Core_Service.Domain.Entities
{ 
    public class CoSo : BaseAuditableEntity<long>
    {    
        public string MaCoSo { get; set; } = null!;

        public string? TenCoSo { get; set; }

        public string? DiaChi { get; set; }

        public string? SoDienThoai { get; set; }

        public string? Email { get; set; }

        public long TrungTamId { get; set; }

        public TrungTam? TrungTam { get; set; }

        public long TenantId { get; set; }
    }
}