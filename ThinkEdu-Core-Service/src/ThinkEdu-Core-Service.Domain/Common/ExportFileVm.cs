namespace ThinkEdu_Core_Service.Domain.Common
{
    public class ExportFileVm
    {
        public string ExportFileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[] Data { get; set; } = { };
    }
}