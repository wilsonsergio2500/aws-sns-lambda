using Intgr.Interfaces.Base;

namespace Intgr.Interfaces.Functions
{
    public interface IFuncPinPointSender
    {
        string SendSMSMessage(IMessageRequest request);
    }
}
