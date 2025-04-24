namespace ThinkEdu_Core_Service.Application.Models
{
    public class FieldValidateRuleDto
    {
        public string RuleName { get; set; } = null!;
        public string? RuleValue { get; set; }
        public string? ErrorMessage { get; set; }
    }
}