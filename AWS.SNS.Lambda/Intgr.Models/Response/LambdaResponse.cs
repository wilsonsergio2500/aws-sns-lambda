using System;

namespace Intgr.Models.Response
{
    public static class LambdaResponse
    {
        public static dynamic GetSuccessResponse(string messageId) {
            return new { status = "success", response = $"New message sent under reciept id {messageId}" };
        }

        public static dynamic GetFailResponse(Exception e) {
            return new { status = "failed", respone = e.Message.ToString() };
        }

    }
}
