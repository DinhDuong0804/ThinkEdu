namespace ThinkEdu_Core_Service.Application.Models
{
    public class FieldValidateConfigurationDto
    {
        public string FieldName { get; set; } = null!;
        public List<FieldValidateRuleDto> FieldValidateRules { get; set; } = new();
    }
}