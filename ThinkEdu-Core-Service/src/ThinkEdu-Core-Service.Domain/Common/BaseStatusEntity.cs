using System.ComponentModel.DataAnnotations;
using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Domain.Common;

public abstract class BaseStatusEntity<T> : BaseEntity<T>
{
    [Required] 
    public string Status { get; set; } = nameof(EStatus.Active);
}