using Cashoverflow.Brokers.Storages;
using Cashoverflow.Models.Locations;

namespace Cashoverflow.Services.Foundations.Locations;

public class LocationService : ILocationService
{
    private IStorageBroker storageBroker;

    public LocationService(IStorageBroker storageBroker) =>
        this.storageBroker = storageBroker;

    public ValueTask<Location> AddLocationAsync(Location location) =>
        throw new System.NotImplementedException();
}