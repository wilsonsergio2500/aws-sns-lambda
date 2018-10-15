using Intgr.Interfaces.Base;

namespace Intgr.Interfaces.Functions
{
    public interface IFuncMessageSender
    {
        string SendMessage(IMessageRequest request);
    }
}
