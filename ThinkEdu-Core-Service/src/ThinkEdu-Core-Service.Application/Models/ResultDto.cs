namespace ThinkEdu_Core_Service.Application.Models;

public class ResultCreateDto
{
    public List<FieldValidateConfigurationDto> FieldValidates { get; set; } = new();
}

public class ResultUpdateDto<T> : ResultCreateDto where T : class
{
    public T Detail { get; set; } = null!;
}