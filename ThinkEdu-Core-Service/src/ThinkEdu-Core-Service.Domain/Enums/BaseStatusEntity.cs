using System.ComponentModel.DataAnnotations;
using ThinkEdu_Core_Service.Domain.Common;

namespace ThinkEdu_Core_Service.Domain.Enums;

public abstract class BaseStatusEntity<T> : BaseEntity<T>
{
    [Required] 
    public string Status { get; set; } = nameof(EStatus.Active);
}