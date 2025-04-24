using ThinkEdu_Core_Service.Domain.Enums;

namespace ThinkEdu_Core_Service.Application.Models
{
    public class BaseFilterDto
    {
        private int? _page;
        private int? _rows;
        private string? _keySort;
        private List<string>? _memberNames;
        private List<string> _includes = new();
        private ESort _sort = ESort.DESC;
        private bool? _all;
        private string? _keyword;
        private Dictionary<string, string>? _properties;

        public int? Page
        {
            get => _page;
            set => _page = value;
        }

        public int? Rows
        {
            get => _rows;
            set => _rows = value;
        }

        public string? KeySort
        {
            get => _keySort;
            set => _keySort = value;
        }

        public List<string>? MemberNames
        {
            get => _memberNames;
            set => _memberNames = value;
        }

        public List<string> Includes
        {
            get => _includes;
            set => _includes = value;
        }

        public ESort Sort
        {
            get => _sort;
            set => _sort = value;
        }

        public bool? All
        {
            get => _all;
            set => _all = value;
        }

        public string? Keyword
        {
            get => _keyword;
            set => _keyword = value;
        }

        public Dictionary<string, string>? Properties
        {
            get => _properties;
            set => _properties = value;
        }

        public bool GetFiledAll()
        {
            if (_all == true)
                return true;
            return _rows is < 0;
        }
    }
}