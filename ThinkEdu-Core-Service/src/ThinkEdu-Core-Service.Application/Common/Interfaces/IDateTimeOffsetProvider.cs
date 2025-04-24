namespace ThinkEdu_Core_Service.Application.Common.Interfaces
{
    public interface IDateTimeOffsetProvider
    {
        DateTimeOffset UtcNow { get; }
        DateTimeOffset? ConvertToUtc(string input);
    }
}
