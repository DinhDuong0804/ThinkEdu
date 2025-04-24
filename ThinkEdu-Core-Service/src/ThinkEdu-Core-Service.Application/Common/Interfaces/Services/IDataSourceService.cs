using System.Reflection;

namespace ThinkEdu_Core_Service.Application.Common.Interfaces.Services
{
    public interface IDataSourceService
    {
        string? GetTextNameFromPropertyInfo(PropertyInfo profile);
    }
}