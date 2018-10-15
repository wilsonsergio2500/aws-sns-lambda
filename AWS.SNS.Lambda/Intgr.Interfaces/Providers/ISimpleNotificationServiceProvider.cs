using Amazon.SimpleNotificationService;

namespace Intgr.Interfaces.Provider
{
    public interface ISimpleNotificationServiceProvider
    {
        IAmazonSimpleNotificationService GetSimpleNotificationService();
    }
}
