using ThinkEdu_Core_Service.Domain.Common;

namespace ThinkEdu_Core_Service.Domain.Entities
{
    public class Setting : BaseEntity<long>
    {
        public string? SettingKey { get; set; }

        public string? SettingValue { get; set; }

        public long TenantId { get; set; }

        public ToChuc ToChuc { get; set; } = null!;
    }
}
