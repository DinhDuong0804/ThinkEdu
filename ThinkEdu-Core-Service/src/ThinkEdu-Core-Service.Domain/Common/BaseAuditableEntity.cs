namespace ThinkEdu_Core_Service.Domain.Common
{
    public abstract class BaseAuditableEntity<T> : BaseTimeEntity<T>
    {
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
    }
}