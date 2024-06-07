namespace Core.Entities.RequestFeatures
{
    public class RequestParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
    }
}