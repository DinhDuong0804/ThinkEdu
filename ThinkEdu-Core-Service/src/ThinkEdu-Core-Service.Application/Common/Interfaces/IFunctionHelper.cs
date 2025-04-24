using System.Reflection;
using ThinkEdu_Core_Service.Application.Models;
using ThinkEdu_Core_Service.Domain.Common;

namespace ThinkEdu_Core_Service.Application.Common.Interfaces
{
    public interface IFunctionHelper
    {
        bool CheckEnum<T>(string? value, bool ingore = false);
        IEnumerable<PropertyInfo> GetFields<T>();
        FilterBase<T> FilterBase<T, TVM>(BaseFilterDto baseFilterDto, TVM dataFilter);
        void ValidateField(PropertyInfo propertyInfo, List<FieldValidateRuleDto> fieldValidateRules);
    }
}