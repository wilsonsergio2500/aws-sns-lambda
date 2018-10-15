using Amazon.SimpleNotificationService;
using Intgr.Interfaces.Provider;

namespace Intgr.Worker.Providers
{
    public class SimpleNotificationServiceProvider : ISimpleNotificationServiceProvider
    {
        private readonly IAmazonSimpleNotificationService notificationService;
        public SimpleNotificationServiceProvider()
        {
            this.notificationService = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.USWest2);
        }
        public IAmazonSimpleNotificationService GetSimpleNotificationService()
        {
            return this.notificationService;
        }
    }
}
