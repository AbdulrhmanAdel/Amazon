
namespace API.Responses
{
    public class PayloadedResponse<T> : BaseResponse
    {
        public T Data { get; set; }
        public PayloadedResponse(T data)
        {
            Data = data;
        }

    }
}