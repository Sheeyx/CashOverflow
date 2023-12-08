using Cashoverflow.Brokers.Loggings;
using Cashoverflow.Brokers.Storages;
using Cashoverflow.Models.Locations;
using Cashoverflow.Services.Foundations.Locations.Exceptions;

namespace Cashoverflow.Services.Foundations.Locations;

public class LocationService : ILocationService
{
    private IStorageBroker storageBroker;
    private ILoggingBroker loggingBroker;

    public LocationService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }

    public async ValueTask<Location> AddLocationAsync(Location location)
    {
        try
        {
            if (location is null)
            {
                throw new NullLocationExcetion();
            }

            return await this.storageBroker.InsertLocationAsync(location);
        }
        catch (NullLocationExcetion nullLocationExcetion)
        {
            var locationValidationException = new LocationValidationException(nullLocationExcetion);
            this.loggingBroker.LogError(locationValidationException);
            
            throw locationValidationException;
        }
        
    }
}