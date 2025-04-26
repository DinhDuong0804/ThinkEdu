using System.Runtime.Serialization;

namespace ThinkEdu_Core_Service.Domain.Enums
{
    public enum ESort
    {
        [EnumMember(Value = "ASC")]
        ASC,
        [EnumMember(Value = "DESC")]
        DESC
    }
}