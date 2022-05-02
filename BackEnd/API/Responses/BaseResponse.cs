using System.Collections.Generic;

namespace API.Responses
{
    public class BaseResponse
    {
        public IEnumerable<string> Messages { get; set; }

        public BaseResponse(IEnumerable<string> messages = null)
        {
            Messages = messages;
        }
    }
}