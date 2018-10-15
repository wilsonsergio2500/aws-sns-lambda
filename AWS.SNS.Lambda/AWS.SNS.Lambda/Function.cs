using System;
using Amazon.Lambda.Core;
using Intgr.Interfaces.Functions;
using Intgr.Models;
using Intgr.Models.Requests;
using Intgr.Models.Response;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
[assembly: Intgr.DI.Attributes.DIInject()]

namespace AWS.SNS.Lambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public dynamic FunctionHandler(LambdaRequest<MessageRequest> request, ILambdaContext context)
        {

            if (request.headers.ContainsKey("Authorization"))
            {

                if (request.headers["Authorization"] != Environment.GetEnvironmentVariable("AUTH_KEY"))
                {
                    throw new UnauthorizedAccessException();
                }
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

            try
            {
                IFuncMessageSender funcMessageService = (IFuncMessageSender)Intgr.DI.Injection.DIServiceProvider.GetService(typeof(IFuncMessageSender));
                string messageId = funcMessageService.SendMessage(request.body);
                return LambdaResponse.GetSuccessResponse(messageId);
            }
            catch (Exception e)
            {
                return LambdaResponse.GetFailResponse(e);
            }
        }
    }
}
