namespace ThinkEdu_Core_Service.Domain.Common
{
    public partial class ListResponse<T>
    {
        public virtual IEnumerable<T> Results { get; set; }
        public virtual IEnumerable<HeaderTableVm>? Headers { get; set; }
        public virtual int Count { get; set; }

        public ListResponse()
        {
            Results = new List<T> { };
            Headers = new List<HeaderTableVm> { };
            Count = 0;
        }

        public ListResponse(IEnumerable<T> data, IEnumerable<HeaderTableVm>? listHeader, int count = 0)
        {
            Results = data;
            Headers = listHeader;
            Count = count;
        }
    }
}