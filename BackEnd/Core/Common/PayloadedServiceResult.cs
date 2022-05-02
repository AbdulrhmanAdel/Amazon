namespace Core.Common
{
    public class PayloadedServiceResult<T> : ServiceResult
    {
        public T Payload { get; set; }
    }
}