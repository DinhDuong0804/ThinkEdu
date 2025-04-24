using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Domain.Common
{
    public abstract class BaseTimeEntity<T> : BaseStatusEntity<T>
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}