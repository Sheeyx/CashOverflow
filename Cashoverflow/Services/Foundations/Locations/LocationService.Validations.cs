using Cashoverflow.Models.Locations;
using Cashoverflow.Services.Foundations.Locations.Exceptions;

namespace Cashoverflow.Services.Foundations.Locations;

public partial class LocationService
{
    private static void ValidateLocationNotNull(Location location)
    {
        if (location is null)
        {
            throw new NullLocationExcetion();
        }
    }
}