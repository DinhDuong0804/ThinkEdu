using System.Reflection;

namespace ThinkEdu_Core_Service.Application.Common.Interfaces
{
    public interface IDataSourceService
    {
        string? GetTextNameFromPropertyInfo(PropertyInfo profile);
    }
}