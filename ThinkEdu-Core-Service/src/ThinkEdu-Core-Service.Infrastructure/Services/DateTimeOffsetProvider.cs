using ThinkEdu_Core_Service.Application.Common.Interfaces.Services;

namespace ThinkEdu_Core_Service.Infrastructure.Services
{
    public class DateTimeOffsetProvider : IDateTimeOffsetProvider
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
        public DateTimeOffset? ConvertToUtc(string input)
        {
            if (DateTimeOffset.TryParseExact(input, "yyyy-MM-dd HH:mm:sszz",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out var parsedDateTimeOffset))
            {
                // Nếu thành công, sẽ trả về DateTimeOffset với giờ mặc định là 00:00:00
                return parsedDateTimeOffset.ToUniversalTime();
            }
            return null;
        }
    }
}