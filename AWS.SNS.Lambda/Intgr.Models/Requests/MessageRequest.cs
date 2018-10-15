using Intgr.Interfaces.Base;

namespace Intgr.Models.Requests
{
    public class MessageRequest : IMessageRequest
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
