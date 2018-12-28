using Amazon.Pinpoint;

namespace Intgr.Interfaces.Providers
{
    public interface IPinPointServiceProvider
    {
        IAmazonPinpoint GetAmazonPinpointService();
    }
}
