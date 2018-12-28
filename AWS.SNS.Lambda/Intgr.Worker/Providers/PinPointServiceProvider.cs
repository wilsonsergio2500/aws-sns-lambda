using Amazon.Pinpoint;
using Intgr.Interfaces.Providers;

namespace Intgr.Worker.Providers
{
    public class PinPointServiceProvider : IPinPointServiceProvider
    {
        private readonly IAmazonPinpoint pinpointService;
        public PinPointServiceProvider()
        {
            this.pinpointService = new AmazonPinpointClient(Amazon.RegionEndpoint.USWest2);
        }


        public IAmazonPinpoint GetAmazonPinpointService()
        {
            return this.pinpointService;
        }
    }
}
