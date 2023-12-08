using Cashoverflow.Models.Locations;
using Cashoverflow.Services.Foundations.Locations.Exceptions;
using Xeptions;

namespace Cashoverflow.Services.Foundations.Locations;

public partial class LocationService
{
    private delegate ValueTask<Location> ReturningLocationFunction();

    private async ValueTask<Location> TryCatch(ReturningLocationFunction returningLocationFunction)
    {
        try
        {
            return await returningLocationFunction();
        }
        catch (NullLocationExcetion nullLocationExcetion)
        {
            throw CreateAndLogValidationException(nullLocationExcetion);
        }
    }

    private LocationValidationException CreateAndLogValidationException(Xeption exception)
    {
        var locationValidationException = new LocationValidationException(exception);
        this.loggingBroker.LogError(locationValidationException);
        return locationValidationException;
    }
}