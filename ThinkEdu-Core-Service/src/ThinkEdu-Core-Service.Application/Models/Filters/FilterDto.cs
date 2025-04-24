using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Application.Models.Filters
{
    public class FilterDto
    {
        public string Label { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string Type { get; set; } = nameof(ETypeProperty.String);
        public SourceDto[] Sources { get; set; } = null!;

    }

    public class SourceDto
    {
        public string Label { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
