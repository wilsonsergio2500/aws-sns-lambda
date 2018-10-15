using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Intgr.Interfaces.Base;
using Intgr.Interfaces.Functions;
using Intgr.Interfaces.Provider;
using Intgr.Worker.Utils;
using System;

namespace Intgr.Worker.Functions
{
    public class FuncMessageSender : IFuncMessageSender
    {
        private readonly IAmazonSimpleNotificationService snsService;
        public FuncMessageSender(ISimpleNotificationServiceProvider provider)
        {
            this.snsService = provider.GetSimpleNotificationService();
        }

        public string SendMessage(IMessageRequest request)
        {
            PublishRequest publishRequest = new PublishRequest();
            bool valid = Helpers.IsPhoneNumberValid(request.PhoneNumber);
            if (valid)
            {
                try
                {
                    string phone = Helpers.GetPhoneDigits(request.PhoneNumber);
                    publishRequest.Message = request.Message;
                    publishRequest.PhoneNumber = $"+1{phone}";
                    PublishResponse response = this.snsService.PublishAsync(publishRequest).Result;
                    return response.MessageId;
                }
                catch (Exception ex) {
                    throw ex;
                }

            }
            else {
                throw new ArgumentException($"{request.PhoneNumber} is not a valid phone format");
            }
        }

        
    }
}
