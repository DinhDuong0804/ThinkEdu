namespace ThinkEdu_Core_Service.Domain.Common
{
    public abstract class BaseTimeEntity<T> : BaseStatusEntity<T>
    {
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
       
    }
}