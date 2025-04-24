namespace ThinkEdu_Core_Service.Domain.Common
{
    public class DataCsvExport<T> where T : class
    {
        public IEnumerable<T> RowsData { get; set; } = new List<T>();
        public HeaderTableVm[] RowHeader { get; set; } = { };
        public string Title { get; set; } = null!;
    }
}