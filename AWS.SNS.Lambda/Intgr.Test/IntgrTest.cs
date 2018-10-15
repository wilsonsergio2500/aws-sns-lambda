using Intgr.DI.Attributes;
using Intgr.Interfaces.Functions;
using Intgr.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intgr.Test
{
    [TestClass]
    public class IntgrTest
    {

        public IntgrTest()
        {
            new DIInject();
        }

        [TestMethod]
        public void SNSSendMessageTest()
        {
            IFuncMessageSender funcMessageService = (IFuncMessageSender)DI.Injection.DIServiceProvider.GetService(typeof(IFuncMessageSender));
            MessageRequest request = new MessageRequest
            {
                PhoneNumber = "4023509079",
                Message = "Here is my message"
            };
            string messageId = funcMessageService.SendMessage(request);
            Assert.IsNotNull(messageId);
        }
    }
}
