namespace ThinkEdu_Core_Service.Domain.Common
{
    public abstract class BaseDto<T>
    {
        public T Id { get; set; } = default!;
    }
}