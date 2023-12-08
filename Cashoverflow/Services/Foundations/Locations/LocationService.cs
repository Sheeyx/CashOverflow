using Cashoverflow.Brokers.Loggings;
using Cashoverflow.Brokers.Storages;
using Cashoverflow.Models.Locations;
using Cashoverflow.Services.Foundations.Locations.Exceptions;

namespace Cashoverflow.Services.Foundations.Locations;

public partial class LocationService : ILocationService
{
    private IStorageBroker storageBroker;
    private ILoggingBroker loggingBroker;

    public LocationService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
    }
    
    public ValueTask<Location> AddLocationAsync(Location location) =>
        TryCatch(async () =>
        {
            ValidateLocationNotNull(location);

            return await this.storageBroker.InsertLocationAsync(location);
        });

}