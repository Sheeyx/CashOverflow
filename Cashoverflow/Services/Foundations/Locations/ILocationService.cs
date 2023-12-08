using Cashoverflow.Brokers.Storages;
using Cashoverflow.Models.Locations;

namespace Cashoverflow.Services.Foundations.Locations;

public interface ILocationService
{
    ValueTask<Location> AddLocationAsync(Location location);
}