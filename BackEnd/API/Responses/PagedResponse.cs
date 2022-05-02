namespace API.Responses
{
    public class PagedResponse<T> : PayloadedResponse<T>
    {
        public int TotalCount { get; set; }

        public PagedResponse(T data, int totalCount) : base(data)
        {
            TotalCount = totalCount;
        }
    }
}