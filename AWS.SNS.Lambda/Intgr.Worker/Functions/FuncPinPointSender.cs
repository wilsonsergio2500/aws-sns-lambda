using Amazon.Pinpoint;
using Intgr.Interfaces.Base;
using Intgr.Interfaces.Functions;
using Intgr.Interfaces.Providers;
using Intgr.Worker.Utils;
using System;
using System.Collections.Generic;

namespace Intgr.Worker.Functions
{

    public class FuncPinPointSender : IFuncPinPointSender
    {
        private readonly IAmazonPinpoint pinpointService;

        public FuncPinPointSender(IPinPointServiceProvider provider)
        {
            this.pinpointService = provider.GetAmazonPinpointService();
        }

        public string SendSMSMessage(IMessageRequest request)
        {
            Dictionary<string, Amazon.Pinpoint.Model.AddressConfiguration> addresses = new Dictionary<string, Amazon.Pinpoint.Model.AddressConfiguration>();
            bool valid = Helpers.IsPhoneNumberValid(request.PhoneNumber);
            if (valid)
            {
                try
                {
                    string phone = Helpers.GetPhoneDigits(request.PhoneNumber);
                    addresses.Add($"+1{phone}", new Amazon.Pinpoint.Model.AddressConfiguration { ChannelType = Amazon.Pinpoint.ChannelType.SMS });
                    Amazon.Pinpoint.Model.DirectMessageConfiguration messageConfiguration = new Amazon.Pinpoint.Model.DirectMessageConfiguration
                    {
                        SMSMessage = new Amazon.Pinpoint.Model.SMSMessage { Body = request.Message, MessageType = Amazon.Pinpoint.MessageType.TRANSACTIONAL }
                    };
                    Amazon.Pinpoint.Model.MessageRequest messageRequest = new Amazon.Pinpoint.Model.MessageRequest
                    {
                        Addresses = addresses,
                        MessageConfiguration = messageConfiguration
                    };
                    Amazon.Pinpoint.Model.SendMessagesRequest sendmessagesRequest = new Amazon.Pinpoint.Model.SendMessagesRequest
                    {
                        ApplicationId = "faaa84bb7f5d4a2a8348837876378e53",
                        MessageRequest = messageRequest
                    };
                    Amazon.Pinpoint.Model.SendMessagesResponse response = this.pinpointService.SendMessagesAsync(sendmessagesRequest).Result;
                    return response.ResponseMetadata.RequestId;

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
