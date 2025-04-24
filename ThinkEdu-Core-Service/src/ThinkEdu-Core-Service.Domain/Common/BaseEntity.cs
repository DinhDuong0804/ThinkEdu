using System.ComponentModel.DataAnnotations;

namespace ThinkEdu_Core_Service.Domain.Common;

public abstract class BaseEntity<T>
{
    [Key] public T Id { get; set; } = default!;
}