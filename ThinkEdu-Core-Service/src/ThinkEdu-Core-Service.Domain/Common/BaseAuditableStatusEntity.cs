using System.ComponentModel;
using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Domain.Common
{
    public abstract class BaseAuditableStatusEntity<T> : BaseAuditableEntity<T>
    {
        [DefaultValue(EStatus.Active)]
        public EStatus TrangThai { get; set; } = EStatus.Active;
    }
}