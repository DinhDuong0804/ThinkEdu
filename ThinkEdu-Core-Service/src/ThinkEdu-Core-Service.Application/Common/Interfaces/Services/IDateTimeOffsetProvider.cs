namespace ThinkEdu_Core_Service.Application.Common.Interfaces.Services
{
    public interface IDateTimeOffsetProvider
    {
        DateTimeOffset UtcNow { get; }
        DateTimeOffset? ConvertToUtc(string input);
    }
}
